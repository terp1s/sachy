using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fajly2
{
    class Sachovnice
    {
        int[,] board;
        List<Tuple<int, int>> figurky;

        Tuple<int, int> start;
        Tuple<int, int> cil;

        Queue<Tuple<int, int>> que;

        public void Nacitani()
        {
            board = new int[8, 8];
            
            figurky = new List<Tuple<int, int>>();

            int pocetFigurek = int.Parse(Console.ReadLine());

            for(int i = 0; i < pocetFigurek; i++)
            {
                figurky.Add(Tuplify());
                board[figurky[i].Item1, figurky[i].Item2] = -1;
            }

            start = Tuplify();
            cil = Tuplify();
            que = new Queue<Tuple<int, int>>();
            que.Enqueue(start);
        }

        public Tuple<int,int> Tuplify()
        {
            string radka = Console.ReadLine();

            string[] cisla = radka.Split(' ');
            int t1 = int.Parse(cisla[0]);
            int t2 = int.Parse(cisla[1]);

            return new Tuple<int, int>(t1, t2);
        }

        public int Search()
        {
            while (board[cil.Item1, cil.Item2] == 0 || !(que.Count == 0))
            {
                Jumpii(que.Dequeue());
            }

            if(board[cil.Item1, cil.Item2] == 0)
            {
                return -1;
            }
            else
            {
                return board[cil.Item1, cil.Item2];
            }

        }

        public void Jumpii(Tuple<int, int> startik)
        {
            for (int x = -2; x < 3; x++)
            {
                for (int y = -2; y < 3; y++)
                {
                    if (startik.Item1 + x > 7 || startik.Item1 + x < 0 || startik.Item2 + y > 7 || startik.Item2 + y < 0 || x == 0 || y == 0)
                    {

                    }
                    else
                    {
                        if (board[startik.Item1 + x, startik.Item2 + y] == 0)
                        {
                            board[startik.Item1 + x, startik.Item2 + y] = board[startik.Item1, startik.Item2] + 1;
                            que.Enqueue(new Tuple<int, int>(startik.Item1 + x, startik.Item2 + y));
                        }
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sachovnice sach = new Sachovnice();
            sach.Nacitani();
            Console.WriteLine(sach.Search());

            Console.ReadKey();
        }
    }
}
