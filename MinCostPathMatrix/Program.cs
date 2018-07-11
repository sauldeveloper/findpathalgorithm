using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCostPathMatrix
{
    class Program
    {
        
        // A utility function that 
        // returns minimum of 3 integers 
        private static int min(int x, int y, int z)
        {
            if (x < y)
                return (x < z) ? x : z;
            else
                return (y < z) ? y : z;
        }


        private static int minCost(int[,] cost, int r, int c)
        {
            int i, j;
            int minIndex;
            int[,] tc = new int[r + 1, c + 1];

            tc[0, 0] = cost[0, 0];

            //Console.WriteLine(cost[5, 5]);

            int sumTC = 0;
            /* Initialize first column of total cost(tc) array */
            for (i = 1; i <= r; i++)            //It goes row by row
            {
                tc[i, 0] = tc[i - 1, 0] + cost[i, 0];
                sumTC = tc[i, 0];
                //Console.WriteLine("i= " + i);
            }
            Console.WriteLine("tc= " + sumTC);

            //int vtc = 0;
            int sumTR = 0;
            int[] arr = new int[r+1];
            int rowUP=0;
            int rowDN = 0;

            /* Initialize first row of tc array */
            for (j = 1; j <= c; j++)            //It goes column by column
            {
                //tc[0, j] = tc[0, j - 1] + cost[0, j];
                //sumTR = tc[0, j];
            }
            Console.WriteLine("tr= " + sumTR);

            //Select small number first column
            for (i = 1; i <= arr.Length; i++)            //Row by Row
            {
                arr[i-1] = cost[i-1, 0];
                //Console.WriteLine(cost[i - 1, 0]);
            }
            //Console.WriteLine(arr[0] + " " + arr[1] + " " + arr[2] + " " + arr[3] + " " + arr[4] + " " + arr[5]);
            //Console.WriteLine(arr.Min());
            for (i = 1; i <= arr.Length; i++)
            {
                if (arr.Min() == cost[i - 1, 0])
                {
                    minIndex = i;
                }
            }

            /* Construct rest of the tc array */
            for (j = 1; j <= c; j++)        //Column by Column
            //for (i = 1; i <= m; i++)            //Row by Row
            {
                //for (j = 1; j <= n; j++)        //Column by Column
                for (i = 1; i <= r+1; i++)            //Row by Row
                {
                    //tc[i, j] = min(tc[i - 1, j - 1],
                    //            tc[i - 1, j],
                    //            tc[i, j - 1]) + cost[i, j];

                    if (i == 1) { rowUP = r; rowDN = i; } else if (i == r+1) { rowDN = 0; rowUP = i - 2; } else { rowUP = i-2; rowDN = i;}

                    //tc[i - 1, j - 1] = min(tc[rowUP, j],
                    //            tc[i - 1, j],
                    //            tc[rowDN, j]) + cost[i - 1, j - 1];
                    tc[i - 1, j - 1] = min(cost[rowUP, j],
                                                    cost[i - 1, j],
                                                    cost[rowDN, j]) + cost[i - 1, j - 1];



                    //tc[i - 1, j - 1] = min(tc[row - 2, j],
                    //            tc[row - 1, j],
                    //            tc[row, j]); //+ cost[i - 1, j - 1];


                    //tc[i - 1, j - 1] = min(tc[row, j],
                    //            tc[i, j + 1],
                    //            tc[row, j]) + cost[i, j];

                    //Console.WriteLine("rowUP= " + rowUP + " rowDN= " + rowDN + " i= " + i + " j= " + j);
                    //Console.WriteLine(" i:" + (i - 1) + " j:" + (j - 1) + " tc:" + tc[i - 1, j - 1] +
                    //    " i:" + (i - 1) + " j:" + j + " tc:" + tc[i - 1, j] +
                    //    " i:" + i + " j:" + (j - 1) + " tc:" + tc[i, j - 1]);
                    Console.WriteLine(tc[i - 1, j - 1] + " UP:" + cost[rowUP, j] + " CE:" + cost[i - 1, j] + " DN:" + cost[rowDN, j]);
                    //Console.WriteLine(tc[i - 1, j - 1] + " UP:" + rowUP + " CE:" + (i - 1) + " DN:" + rowDN);
                    //vtc = tc[i, j];

                }
                //Console.WriteLine(tc[4, 1] + " UP:" + cost[3, 1] + " CE:" + cost[4, 1] + " DN:" + cost[0, 1]);
                Console.WriteLine("-");
                //Console.WriteLine("row= " + row + " i= " + i + " j= " + j);
                //Console.WriteLine(vtc.ToString());
            }

            Console.WriteLine("r:" + r + " c:" + c);
            return tc[r, c];

        }


        //public static void Fill<T>(this T[] array, T value)
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        array[i] = value;
        //    }
        //}





        static void Main(string[] args)
        {
            int[,] cost = {{3, 4, 1, 2 ,8, 6},
                           {6, 1, 8, 2, 7, 4},
                           {5, 9, 3, 9, 9, 5},
                           {8, 4, 1, 3, 2, 6},
                           {3, 7, 2, 8, 6, 4}
                           //{3, 7, 2, 1, 2, 3}

            //int[,] cost = {{3, 6, 5, 8 ,8, 0},
            //               {4, 1, 9, 4, 4, 0},
            //               {1, 8, 3, 1, 1, 0},
            //               {2, 2, 9, 3, 3, 0},
            //               {8, 7, 9, 2, 2, 0},
            //               {6, 4, 5, 6, 6, 0}


                    };

            //Console.WriteLine(min(4, 8, 6));
            //row, column
            Console.WriteLine(minCost(cost, 4, 5));

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
