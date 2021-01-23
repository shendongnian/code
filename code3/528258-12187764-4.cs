                char value = 'a';
                Dictionary<string, long> tests = new Dictionary<string, long>()
                {
                    {"test1", 0},
                    {"test2", 0},
                    {"test3", 0},
                    {"test4", 0},
                    {"test5", 0},
                    {"test6", 0},
                    {"test7", 0},
                    {"test8", 0},
                    {"test9", 0},
                    {"test10", 0}
                };
                Stopwatch watch = new Stopwatch();
                // tested with 1, 100 and 100 000
                long X = 1;
    
                for (int i = 0; i < X; i++)
                {
                    watch.Start();
                    if ("ahxz".Any(c => c == value))
                    {
                    }
                    watch.Stop();
                    tests["test1"] += watch.ElapsedTicks;
                    watch.Reset();
    
                    watch.Start();
                    if (value == 'a' || value == 'h' || value == 'x' || value == 'z')
                    {
                    }
                    watch.Stop();
                    tests["test2"] += watch.ElapsedTicks;
                    watch.Reset();
    
                    watch.Start();
                    if (new[] { 'a', 'h', 'x', 'z' }.Contains(value))
                    {
                    }
                    watch.Stop();
                    tests["test3"] += watch.ElapsedTicks;
                    watch.Reset();
    
                    watch.Start();
                    if (new[] { 'a', 'h', 'x', 'z' }.Contains(value))
                    {
                    }
                    watch.Stop();
                    tests["test4"] += watch.ElapsedTicks;
                    watch.Reset();
    
                    watch.Start();
                    if ("ahxz".Contains(value))
                    {
                    }
                    watch.Stop();
                    tests["test5"] += watch.ElapsedTicks;
                    watch.Reset();
    
                    watch.Start();
                    if ("hxza".Any(c => c == value))
                    {
                    }
                    watch.Stop();
                    tests["test6"] += watch.ElapsedTicks;
                    watch.Reset();
    
                    watch.Start();
                    if (value == 'h' || value == 'x' || value == 'z' || value == 'a')
                    {
                    }
                    watch.Stop();
                    tests["test7"] += watch.ElapsedTicks;
                    watch.Reset();
    
                    watch.Start();
                    if (new[] { 'h', 'x', 'z', 'a' }.Contains(value))
                    {
                    }
                    watch.Stop();
                    tests["test8"] += watch.ElapsedTicks;
                    watch.Reset();
    
                    watch.Start();
                    if (new[] { 'h', 'x', 'z', 'a' }.Contains(value))
                    {
                    }
                    watch.Stop();
                    tests["test9"] += watch.ElapsedTicks;
                    watch.Reset();
    
                    watch.Start();
                    if ("hxza".Contains(value))
                    {
                    }
                    watch.Stop();
                    tests["test10"] += watch.ElapsedTicks;
                    watch.Reset();
                }
    
                foreach (var test in tests.OrderBy(p => p.Value))
                {
                    Console.WriteLine("Average of ticks for {0} : {1}\n", test.Key, test.Value / nbrOfTimes);
                }
                
                Console.ReadLine();
