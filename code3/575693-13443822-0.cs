        int[] list = new int[100];
        Random rand = new Random();
        for(int k = 0; k < list.Length; k++)
        {
            list[k] = rand.Next(0, 200000);
        }
        object monitor = new object();
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        char[] result = new char[list.Length * list.Max().ToString().Length];//worst case scenario.
        for (int j = 0; j < 120000; j++)
        {
            //partitioning.
            Parallel.ForEach(Partitioner.Create(0, list.Length), () => 0.0, (range, state, local) =>
            {
                StringBuilder xc = new StringBuilder();
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    //split the number into characters.
                    int number = list[i];
                    int index = i;
                    do
                    {
                        int lsd = number % 10;       // Get least significant // digit
                        result[index++] = (char)(lsd + 47);
                        number /= 10;                        // Prepare for next most  // significant digit
                    } while(number != 0);
                }
                return 0.0;
            }, local => {});
        }
        stopwatch.Stop(); MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
