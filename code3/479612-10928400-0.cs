    class Program
    {
        static void Main(string[] args)
        {
            var items = new Dictionary<ItemType, List<int>>();
            items[ItemType.Type1] = new List<int> { 1, 2, 3, 4, 5 };
            items[ItemType.Type2] = new List<int> { 11, 12, 13, 15 };
            items[ItemType.Type3] = new List<int> { 21, 22, 23, 24, 25, 26 };
            int numItemsTaken = 0;
            var resultsList = new List<int>();
            int n = 2, startpoint = 0, previousListSize = 0;
            
            do
            {
                items.ToList().ForEach(x => resultsList.AddRange(x.Value.Skip(startpoint).Take(n)));
                startpoint += n;
                numItemsTaken = resultsList.Count - previousListSize;
                previousListSize = resultsList.Count;
            } 
            while (numItemsTaken > 0);
            Console.WriteLine(string.Join(", ", resultsList));
            Console.ReadKey();
        }
        enum ItemType { Type1 = 1, Type2 = 2, Type3 = 3 };
    }
