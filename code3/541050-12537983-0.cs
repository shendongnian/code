    class Program
    {
        static void Main(string[] args)
        {
            List<SortMe> SortMes = new List<SortMe>();
    
            SortMes.Add(new SortMe("aaa"));
            SortMes.Add(new SortMe("bbb"));
            SortMes.Add(new SortMe("ccc"));
            SortMes.Add(new SortMe("aaa"));
            SortMes.Add(new SortMe("bbb"));
            SortMes.Add(new SortMe("ccc"));
            SortMes.Add(new SortMe("ccc"));
            SortMes.Add(new SortMe("bbb"));
            SortMes.Add(new SortMe("aaa"));
            SortMes.Add(new SortMe("ccc"));
            SortMes.Add(new SortMe("bbb"));
            SortMes.Add(new SortMe("aaa"));
    
            SortMe SortMeLast = null;
    
            foreach (SortMe SortMeCurrent in SortMes.OrderBy(x => x.Name))
            {
                Console.WriteLine("   Current     " + SortMeCurrent.Name);
                if (SortMeLast != null)
                {
                    if (SortMeCurrent.Name != SortMeLast.Name)
                    {
                        // do something
                        Console.WriteLine("Do Something");
                    }
                }
                SortMeLast = SortMeCurrent;
            }
            Console.ReadLine();
        }
    }
    public class SortMe
    {
        public string Name { get; set; }
        public SortMe(string name) { Name = name; } 
    }
