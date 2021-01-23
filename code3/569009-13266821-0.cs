    static void Main(string[] args)
        {
            var test = string.Empty;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            if (test.Length == 0)
            {
                sw.Stop();
                Console.WriteLine("String is empty!  " + sw.ElapsedTicks);
            }
            sw.Restart();
            if (!(test.Any()))
            {
                sw.Stop();
                Console.WriteLine("String is empty!  " + sw.ElapsedTicks);
            }
            sw.Restart();
            if (String.IsNullOrWhiteSpace(test))
            {
                sw.Stop();
                Console.WriteLine("String is empty!  " + sw.ElapsedTicks);
            }
            sw.Restart();
            if (String.IsNullOrEmpty(test))
            {
                sw.Stop();
                Console.WriteLine("String is empty!  " + sw.ElapsedTicks);
            }
            sw.Restart();
            if (test.Count() == 0)
            {
                sw.Stop();
                Console.WriteLine("String is empty!  " + sw.ElapsedTicks);
            }
            sw.Restart();
            var s = Convert.ToString(test);
            sw.Stop();
            Console.WriteLine("String is empty!  " + sw.ElapsedTicks);
            sw.Restart();
            s = test.ToString(CultureInfo.InvariantCulture);
            sw.Stop();
            Console.WriteLine("String is empty!  " + sw.ElapsedTicks);
            Console.ReadKey();
        }
