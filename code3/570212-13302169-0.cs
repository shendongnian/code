    void Main()
        {
            SortedDictionary<string, int> dict =Words();
            display(dict);
            Console.WriteLine();
        }
        private static SortedDictionary<String, int> Words()
        {
            SortedDictionary<string, int> dic = new SortedDictionary<string, int>();
            String input = "today is Wednesday right and it sucks. today how are you are you a rabbit today";
            string[] word = Regex.Split(input, @"\s");
            foreach (string current in word)
            {
                string wordKey = current.ToLower();
                if (dic.ContainsKey(wordKey))
                {
                    ++dic[wordKey];
                }
                else
                {
                    dic.Add(wordKey, 1);
                }
            }
            return dic;
        }
        private static void display(SortedDictionary<string, int> dictionary)
        {
             var items = from pair in dictionary
                    orderby pair.Value descending
                    select pair;
			var dict = items.GroupBy(x=>x.Value).ToDictionary(y=> y.Key, y=> String.Join(" ", y.Select(z=>z.Key)));
	          foreach (var item in dict)
             {
                 Console.WriteLine("Words occurung "+item.Key +" times");
                 Console.WriteLine("{0}", item.Value);
             }
            Console.ReadLine();
        }
