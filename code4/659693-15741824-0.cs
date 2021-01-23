    class Program
        {
            private static void Main(string[] args)
            {
                Dictionary<string, uint> oSomeDictionary = new Dictionary<string, uint>();
    
                oSomeDictionary.Add("dart1", 1);
                oSomeDictionary.Add("card2", 1);
                oSomeDictionary.Add("dart3", 2);
                oSomeDictionary.Add("card4", 0);
                oSomeDictionary.Add("dart5", 3);
                oSomeDictionary.Add("card6", 1);
                oSomeDictionary.Add("card7", 0);
    
                var result = oSomeDictionary.Where(pair => pair.Key.StartsWith("card") && pair.Value > 0 );
                foreach (var kvp in result)
                {
                    Console.WriteLine("{0} : {1}",kvp.Key,kvp.Value);
                }
                Console.ReadLine();
            }
       }
