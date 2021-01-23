    internal static List<Country> Ort()
    {
       Country country = new Country();
       Country.Name="Germany";
       Country.Cities = new List<City>();  
       
       City city1 = new City();
       city1.Name="Frankfurt";
       city1.Regions = new List<Region>();
      
       Region region = new Region(); 
       region.Name = "Siemensweg";
       region.code = 14;
       
       city1.Regions.Add(region);
       
       region = new Region();
       region.Name = Bernstr;
       region.Code = 4;
       city1.Regions.Add(region);
       
       country.Cities.Add(city1);
       List<Country> countries = new List<Country>();
       countries.Add(country);
    
       return countries;   
       //or you can make your classes in a loop on a table row collection 
     
    }
