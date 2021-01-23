            Stopwatch stopwatch = new Stopwatch();
            var list = new List<string>();
            for (int i = 0; i < 5000000; ++i)
            {
                list.Add(i.ToString());
            }
            stopwatch.Start();
            var lookup = list.ToLookup(x => x);
            stopwatch.Stop();
            Console.WriteLine("Creation: " + stopwatch.Elapsed);
            // ... Same but for ToDictionary
            var lookup = list.ToDictionary(x => x);
            // ...
