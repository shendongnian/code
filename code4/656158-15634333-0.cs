    public class County
    {
        public string Name{get;set;}
        public List<City> Cities{get;set;}
    }
    
    public class City
    {
      public string Name{get;set;}
       public List<Region> {get;set;}
    }
    
    public class Region
    {
      public string Name{get;set;}
      public int Code{get;set;}
    }
