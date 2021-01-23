    class Program
    {
        static void Main(string[] args)
        {
            var searchedTerm = "test2-ns";
            Dictionary<string, string> dictCatalogue = 
                new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            dictCatalogue.Add("test1", "value1");
            dictCatalogue.Add("Test2", "value2");
            // looking for the key with removed "-ns" suffix
            var value = dictCatalogue[searchedTerm
                .Substring(0, searchedTerm.Length - 3)];
            Console.WriteLine(value);
        }
    }
    // Output
    value2
