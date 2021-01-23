    class SearchClass
    {
        public String InputString { get; private set; }
        public int StartPos { get; private set; }
        public List<string> completeModels;
        public List<string> partialModels;
    
        public SearchClass(string s, int sPos)
        {
            InputString = s;
            StartPos = sPos;
            completeModels = new List<string>();
            partialModels = new List<string>();
        }
    
        public void Run(int strandID)
        {
            // SearchAlgorithm.SearchInOneDirection(...);
        }
    
        // public static void CombineResult(...){ };
    }
    
    class Program
    {
        static void Main(string s, int strandID)
        {      
            int lenCutoff = 10000;
    
            if (s.Length > lenCutoff)
            {
                var searches = new List<SearchClass>();
                var tasks = new List<System.Threading.Tasks.Task>();
    
                for (int i = 0; i < s.Length; i += lenCutoff)
                {
                    SearchClass newSearch = new SearchClass(s.Substring(i, lenCutoff), i);
                    searches.Add(newSearch);
                    tasks.Add(System.Threading.Tasks.Task.Factory.StartNew(()=>newSearch.Run(strandID)));
                }
    
                System.Threading.Tasks.Task.WaitAll(tasks.ToArray());
    
                // Combine the result
            }
        }
    }
