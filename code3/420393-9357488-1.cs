        static void Main(string[] args)
        {
            Random rand = new Random();
            int[,] data = new int[100,1000];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = rand.Next(0, 1000);
                }
            }
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 100; i++)
            {
                int[][] dataJagged = AsJagged(data);
            }
            Console.WriteLine("AsJagged:  " + sw.Elapsed);
            sw = Stopwatch.StartNew();
            for (int i = 0; i < 100; i++)
            {
                int[][] dataJagged2 = AsJagged2(data);
            }
            Console.WriteLine("AsJagged2: " + sw.Elapsed);
        }
