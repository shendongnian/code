    static void Main(string[] args)
            {
                
                Dictionary<String, Int32> outputDictionary = new Dictionary<String, Int32>();
                outputDictionary.Add("3º value", 1);
                outputDictionary.Add("2º value", 2);
                outputDictionary.Add("1º value", 10);
                outputDictionary.Add("5º value", 20);
                outputDictionary.Add("4º value", 5);
                outputDictionary.Add("14º value", 8);
                outputDictionary.Add("10º value", 22);
    
                IOrderedEnumerable<KeyValuePair<string,int>> NewOrder = outputDictionary.OrderBy(k => int.Parse(Regex.Match(k.Key, @"\d+").Value));
    
                foreach (var item in NewOrder)
                {
                    Console.WriteLine(item.Key + " " + item.Value.ToString());
                }
                Console.ReadKey();
            }
