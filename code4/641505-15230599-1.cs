    public class MyObject
    {
        public MyCollection  TypeOnes { get; set;} 
        public MyCollection  TypeTwos { get; set;} 
        public MyCollection  TypeThrees { get; set;} 
    
        public IEnumerable<string> All
        {
            get
            {
                foreach (var item in TypeOnes.Union(TypeTwos).Union(TypeThrees))
                {
                    yield return item;
                }
            }
        }
    }
    
    public class MyCollection : Collection<string>
    {
        public bool IsLoaded { get; set; }
    }
