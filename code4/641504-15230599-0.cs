    class MyObject{
        public MyCollection  TypeOnes;
        public MyCollection  TypeTwos;
        public MyCollection  TypeThrees;
    
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
    
    class MyCollection : Collection<string>
    {
        public bool IsLoaded;
    }
