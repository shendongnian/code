        static void Main(string[] args)
        {
            IDictionary<int, string> test = new Dictionary<int, string>();
            var castedDictionary = (IDictionary)test;
            castedDictionary.Add(1, "hello");
            Console.Write(test.FirstOrDefault().Key);
            Console.Write(test.FirstOrDefault().Value);
            Console.ReadLine();
        }
