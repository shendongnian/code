        public static IEnumerable<string> GetEnumirator(this StreamReader sr)
        {
            while (!sr.EndOfStream)
            {
                yield return sr.ReadLine();
            }
        }
        public static void ProcessParalel(this StreamReader sr, Action<string> action, int threadsCount)
        {
            ParallelOptions po = new ParallelOptions();
            po.MaxDegreeOfParallelism = threadsCount;
            Parallel.ForEach(sr.GetEnumirator(), po, action);
        }
