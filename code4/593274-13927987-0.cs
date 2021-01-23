     class Program
        {
            static void Main(string[] args)
            {
    
                List<string> myList = new List<string>() { "abc", "DEF", "Def", "aBC" };
    
                CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
                myList=myList.ConvertAll(r => currentCulture.TextInfo.ToTitleCase(r.ToLower()));
                int i=0;
                myList.ForEach(delegate(string k)
                {
                     Console.WriteLine(k);
                     i++;
                });
                Console.ReadLine();
            }
        }
