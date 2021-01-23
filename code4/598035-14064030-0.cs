    namespace ConsoleApplication71
    {
        public class AVGComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                // Null checkings are necessary to prevent null refernce exceptions
                if((x == null) && (y == null)) return 0;
                if(x == null) return -1;
                if(y == null) return 1;
    
                const string avg = @"(avg) ";
    
                if(x.StartsWith(avg) || y.StartsWith(avg))
                {
                    return x.Replace(avg, string.Empty).CompareTo(y.Replace(avg, string.Empty));
                }
    
                return x.CompareTo(y);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<string> myUnsortedList = new List<string>();
    
                myUnsortedList.Add("Alpha");
                myUnsortedList.Add("(avg) Alpha");
                myUnsortedList.Add("Zeta");
                myUnsortedList.Add("Beta");
                myUnsortedList.Add("(avg) Beta");
                myUnsortedList.Add("(avg) Zeta");
    
                var mySortedList = myUnsortedList.OrderByDescending(s => s, new AVGComparer());
    
                foreach (string s in mySortedList)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
