        static void Main(string[] args)
        {
            var sr = new StreamReader(@"d:\test.txt");
            var data = ExtractData(sr).ToArray();
        }
        private static IEnumerable<long[]> ExtractData(StreamReader sr)
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                yield return line.Split(',').Select(i => Convert.ToInt64(i)).ToArray();
            }
        }
