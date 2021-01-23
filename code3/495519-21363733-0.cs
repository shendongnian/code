           static void Main(string[] args)
        {
            Console.WriteLine("enter the size of rows");
            int n = Convert.ToInt32(Console.ReadLine());
            
            int[][] a = new int[n][];
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine("enter the number of elements for row {0}", i + 1);
                int x = Convert.ToInt32(Console.ReadLine());
                a[i]=new int[x];
                for (int j = 0; j < a[i].Length; j++)
                {
                    a[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write(a[i][j]+"\t"); 
                }
                Console.WriteLine();
            }
                Console.ReadKey();
        }
