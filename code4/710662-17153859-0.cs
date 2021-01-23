            bool found;
            double intersect = 0;
            double any = 0;
            Stopwatch stopWatch = new Stopwatch();
            for (int i = 0; i < 100; i++)
            {
                List<string> L1 = GenerateNumberStrings(200000);
                List<string> L2 = GenerateNumberStrings(60000);
                stopWatch.Start();
                found = Intersect(L1, L2);
                stopWatch.Stop();
                intersect += stopWatch.ElapsedMilliseconds;
                
                stopWatch.Reset();
                stopWatch.Start();
                found = Any(L1, L2);
                stopWatch.Stop();
                any += stopWatch.ElapsedMilliseconds;
            }
            Console.WriteLine("Intersect: " + intersect + "ms");
            Console.WriteLine("Any: " + any + "ms");
        }
        private static bool Any(List<string> lst1, List<string> lst2)
        {
            return lst1.Any(x => lst2.Contains(x));
        }
        private static bool Intersect(List<string> lst1, List<string> lst2)
        {
            return lst1.Intersect(lst2).Any();
        }
