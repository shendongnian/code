     private static Random rand = new Random();
        private static void Test()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            string vStreamId = GetNewValues().Where(x => !values.ContainsKey(x)).First();
        }
        public static IEnumerable<string> GetNewValues()
        {
            yield return rand.Next(1000, 9999).ToString();
        }
