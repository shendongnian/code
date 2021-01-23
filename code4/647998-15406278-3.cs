        internal const int RETRIES = 10000000;
        static void Main(string[] args)
        {
            string testString = Guid.NewGuid().ToString();
            long timeSubstring = MeasureSubstring(testString);
            long timeTake = MeasureTake(testString);
            Console.WriteLine("Time substring: {0} ms, Time take: {1} ms",
                timeSubstring, timeTake);
        }
        private static long MeasureSubstring(string test)
        {
            long ini = Environment.TickCount;
            for (int i = 0; i < RETRIES; i++)
            {
                if (test.Length > 4)
                {
                    string tmp = test.Substring(4);
                }
            }
            return Environment.TickCount - ini;
        }
        private static long MeasureTake(string test)
        {
            long ini = Environment.TickCount;
            for (int i = 0; i < RETRIES; i++)
            {
                var data = new string(test.Take(4).ToArray());
            }
            return Environment.TickCount - ini;
        }
