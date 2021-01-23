    static void Main(string[] args)
        {            
            List<string> list = new List<string>();
            list.Add("b lue number 1");
            list.Add("test number 234");
            list.Add("yello number 2334");
            list.Add("yes whippea number 324234");
            list.Add("test number asdf");  
            
            var results = Program.Search(list,"test","1");
            Console.ReadLine();
        }
        public static List<string> Search(List<string> stringsToSearch, params string[] args)
        { 
            return  stringsToSearch.AsParallel().Where(x => args.Any(y => x.Contains(y))).ToList(); 
        }
