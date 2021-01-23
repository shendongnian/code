        private static string DictionaryToString(IDictionary dict) {
            if (null == dict) throw new ArgumentNullException("dict");
            var valueStrings = new List<string>();
            foreach (DictionaryEntry item in dict) {
                valueStrings.Add(item.Key + ": " + item.Value);
            }
            return string.Join("\n", valueStrings.ToArray());
        } 
        private static string Test(object value) {
            
            var dict = value as IDictionary;
            if (dict != null) {
                return DictionaryToString(dict);
            }
            if (value == null) {
                return null;
            }
            return value.ToString();
        }
        private static void Main(string[] args) {
            var aDictionary = new Dictionary<int, string> {
                { 1, "one" },
                { 2, "two" },
                { 3, "three" }
            };
            Console.WriteLine(Test(aDictionary));
            var anotherDictionary = new Dictionary<string, object> {
                { "one", 1 },
                { "two", "2" },
                { "three", new object() }
            };
            Console.WriteLine(Test(anotherDictionary));
            Console.ReadLine();
        }
