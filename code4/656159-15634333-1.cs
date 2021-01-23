    internal static List<Country> Ort()
    {
       Country country = new Country();
       Country.Name="Germany";
       Country.Cities = new List<City>();  
       
       City city1 = new City();
       city1.Name="Frankfurt";
       city1.Regions = new List<Region>();
    }
