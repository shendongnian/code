        static void Main(string[] args)
        {
            foreach(var item in Generate(1, 1000))
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }
        private static IEnumerable<KeyValuePair<int, string>> Generate(int init, int max)
        {
            int current = init;
            var stringBuilder = new StringBuilder();
            while (current <= max)
            {
                if (current % 3 == 0) stringBuilder.Append("FUZZ");
                if (current % 5 == 0) stringBuilder.Append("BIZZ");
                if (current % 7 == 0) stringBuilder.Append("????");
                yield return new KeyValuePair<int, string>(current, stringBuilder.ToString());
                stringBuilder.Clear();
                current++;
            }
        }
