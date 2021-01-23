        public static void Main()
        {
            var seq = new[] { -10M, -2M, -3M };
            var stuff = seq.FindBestSubsequence();
            Console.WriteLine(stuff.Item1 + " " + stuff.Item2 + " " + stuff.Item3);
            Console.ReadLine();
        }
        public static Tuple<decimal, long, long> FindBestSubsequence(this IEnumerable<decimal> source)
        {
            var result = new Tuple<decimal, long, long>(decimal.MinValue, -1L, -1L);
            if (source == null)
            {
                return result;
            }
            var sum = 0M;
            var tempStart = 0L;
            var index = 0L;
            foreach (var item in source)
            {
                sum += item;
                if (sum > result.Item1)
                {
                    result = new Tuple<decimal, long, long>(sum, tempStart, index);
                }
                if (sum < 0)
                {
                    sum = 0;
                    tempStart = index + 1;
                }
                index++;
            }
            return result;
        }
