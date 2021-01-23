    class Program
        {
            public static void Main()
            {
                Print();
                Console.ReadKey();
            }
    
            private static void Print()
            {
                GetListOfWordsByLength();
    
                foreach (var list in WordSortedDictionary)
                {
                    list.Value.ForEach(i => { Console.Write(i + ","); });
                    Console.WriteLine();
                }
            }
    
            private static void GetListOfWordsByLength()
            {
                string input = " aa aaa aaaa bb bbb bbbb cc ccc cccc ";
    
                string[] inputSplitted = input.Split(' ');
    
                inputSplitted.ToList().ForEach(AddToList);
            }
    
            static readonly SortedDictionary<int, List<string>> WordSortedDictionary = new SortedDictionary<int, List<string>>();
    
            private static void AddToList(string s)
            {
                if (s.Length > 0)
                {
                    if (WordSortedDictionary.ContainsKey(s.Length))
                    {
                        List<string> list = WordSortedDictionary[s.Length];
                        list.Add(s);
                    }
                    else
                    {
                        WordSortedDictionary.Add(s.Length, new List<string> {s});
                    }
                }
            }
        }
