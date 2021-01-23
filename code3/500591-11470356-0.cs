        public class Data
        {
            public string Key { get; set; }
            public int Value { get; set; }
        }
        private static void Main(string[] args)
        {
            Dictionary<string, int> dictionary1 = new Dictionary<string, int>();
            dictionary1.Add("key1", 1);
            dictionary1.Add("key2", 2);
            List<Data> data = dictionary1.Select(z => new Data { Key = z.Key, Value = z.Value }).ToList();
            Console.ReadLine();
        }
