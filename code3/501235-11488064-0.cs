        static void Main(string[] args)
        {
            var sr = new StreamReader(@"d:\test.txt");
            long[] data = ExtractData(sr).ToArray();
        }
        private static IEnumerable<long> ExtractData(StreamReader sr)
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var items = line.Split(',');
                foreach (var item in items)
                {
                    yield return Convert.ToInt64(item);
                }
            }
        }
