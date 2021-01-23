    static void Main(string[] args)
        {
            Console.WriteLine("Starting Test");
            var list = new List<int>();
            // 1. Calculating inline without function call
            Stopwatch sw = Stopwatch.StartNew();
            for (int d = 0; d < 100000000; d++)
            {
                int res = d * d;
                list.Add(res);
            }
            sw.Stop();
            Console.WriteLine("Checked: " + sw.ElapsedMilliseconds);
            // 2. Calulating power with function call
            
            list = new List<int>();
            Stopwatch sw2 = Stopwatch.StartNew();
            for (int d = 0; d < 100000000; d++)
            {
                int res = Power(d);
                list.Add(res);
            }
            sw2.Stop();
            Console.WriteLine("Function: " + sw2.ElapsedMilliseconds);
            Console.ReadKey();
        }
