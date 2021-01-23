    public class Country {
          public string CountryName { get; set; }
          public List<CountryRegion> Regions { get; set; } 
    }
   
    pulic class CountryRegion 
    {
         public string RegionName { get; set; }  
         public List<Area> Areas { get; set; }    
    }
    public class Area {
         public string AreaName { get; set; }
         public int Population { get; set; }
    }
        
