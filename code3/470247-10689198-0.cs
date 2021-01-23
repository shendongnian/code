           static void Main()
        {
            const int m = 100000000;
            //just to create an array
            int[] array = new int[100000000];
            for (int x = 0; x < array.Length; x++) {
                array[x] = x;
            }
           
            var s1 = Stopwatch.StartNew();           
            var upperBound = array.Length;
            for (int i = 0; i < upperBound; i++)
            {
              
            }
            s1.Stop();
            GC.Collect();
            var s2 = Stopwatch.StartNew();
            foreach (var item in array) { 
            
            }
            s2.Stop();
            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds *
                1000000) / m).ToString("0.00 ns"));
            Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds *
                1000000) / m).ToString("0.00 ns"));
            Console.Read();
            //2.49 ns
            //4.68 ns
            // In Release Mode
            //0.39 ns
            //1.05 ns
 
    }
