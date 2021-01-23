    class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = new List<string> { "test", "otherTest" };
            List<string> list2 = new List<string> { "item", "otherItem" };
            List<string> list3 = new List<string> { "value", "otherValue" };
            var result = CombineListsByLayers(list1, list2, list3);
        }
        public static List<string>[] CombineListsByLayers(params List<string>[] sourceLists)
        {
            var results = new List<string>[sourceLists[0].Count];
            for (var i = 0; i < results.Length; i++)
                results[i] = new List<string>();
            
            for (var i = 0; i < results.Length; i++)
                foreach (var sourceList in sourceLists)
                    results[i].Add(sourceList[i]);
            return results;
        }
    }
