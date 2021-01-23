    static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string longString = new string('x', 10000) + " ";
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i % 100 == 0 ? "" : longString);
            }
            Stopwatch sw = Stopwatch.StartNew();
            list.Where(r => !string.IsNullOrEmpty(r.Trim())).ToList();
            sw.Stop();
            Console.WriteLine("IsNullOrEmpty(Trim): {0}", sw.ElapsedMilliseconds);
            GC.Collect();
            sw = Stopwatch.StartNew();
            list.Where(r => !string.IsNullOrWhiteSpace(r)).ToList();
            sw.Stop();
            Console.WriteLine("IsNullOrWhitespace: {0}", sw.ElapsedMilliseconds);
            GC.Collect();
            sw = Stopwatch.StartNew();
            //this is result list
            List<string> listResult = new List<string>();
            int countList = list.Count;
            for (int i = 0; i < countList; i++)
            {
                string item = list[i];
                if (!string.IsNullOrWhiteSpace(item))
                {
                    listResult.Add(item);
                }
            }
            sw.Stop();
            Console.WriteLine("Classic for + IsNullOrWhitespace: {0}", sw.ElapsedMilliseconds);
            GC.Collect();
            sw = Stopwatch.StartNew();
            list.AsParallel().Where(r => !string.IsNullOrWhiteSpace(r)).ToList();
            sw.Stop();
            Console.WriteLine("PLINQ IsNullOrWhitespace: {0}", sw.ElapsedMilliseconds);
            Console.Read();
        }
