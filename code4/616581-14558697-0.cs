    public class EssayNameComparer : IComparer<string>
    {
        private Regex _digits = new Regex("(\\d+)(.*)");
        
        public int Compare(string a, string b)
        {
            Match matcha = _digits.Match(a);
            Match matchb = _digits.Match(b);
            
            if (matcha.Success && matchb.Success)
            {
                int numa = int.Parse(matcha.Groups[1].Value);
                int numb = int.Parse(matchb.Groups[1].Value);
                return numa.CompareTo(numb);
            }
            else if (matcha.Success)
            {
                return 1;
            }
            else if (matchb.Success)
            {
                return -1;
            }
            else
            {
                return string.Compare(a, b);
            }            
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Essay> essays= new List<Essay>() { 
                new Essay { ID = 1, Name = "ccccc"},
                new Essay { ID = 2, Name = "aaaa"},
                new Essay { ID = 3, Name = "bbbb"},
                new Essay { ID = 4, Name = "10"},
                new Essay { ID = 5, Name = "1"},
                new Essay { ID = 6, Name = "2"},
                new Essay { ID = 7, Name = "1a"}
            };
              
            foreach(Essay essay in essays.OrderBy(e => e.Name, new EssayNameComparer()))
            {
                Console.WriteLine(essay.Name);
            }
        }
    }
