            Dictionary<int, int> hash = new Dictionary<int, int>();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 10; i++)
            {
                int temp = i;
                var th = new Thread(() =>
                {
                    Thread.Sleep(r.Next(9) * 100);
                    Console.WriteLine("{0} {1}", 
                        Thread.CurrentThread.GetHashCode(), temp);
                });
                hash.Add(th.GetHashCode(), temp);
                th.Start();
            }
            Thread.Sleep(1000);
            Console.WriteLine();
            foreach (var kvp in hash)
                Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
