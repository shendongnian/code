        for (int i = 0; i < 10; i++)
        {
            int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 };
            Stopwatch watch = new Stopwatch();
            watch.Start();
            //Parallel foreach
            Parallel.ForEach(array, line =>
            {
                for (int x = 0; x < 1000000; x++)
                {
                }
               
            });
            watch.Stop();
            Console.WriteLine("Parallel.ForEach {0}", watch.Elapsed.Milliseconds);
            watch = new Stopwatch();
            //foreach
            watch.Start();
            foreach (int item in array)
            {
                for (int z = 0; z < 10000000; z++)
                {
                }
            }
            watch.Stop();
            Console.WriteLine("ForEach {0}", watch.Elapsed.Milliseconds);
            Console.WriteLine("####");
        }
        Console.ReadKey();
