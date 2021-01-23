        static void Main(string[] args)
        {
            var listOfLists = new List<IEnumerable>();
            var names = new List<string>();
            var ages = new List<int>();
            listOfLists.Add(names);
            listOfLists.Add(ages);
            foreach (dynamic list in listOfLists)
            {
                list.Clear();
            }
        }
