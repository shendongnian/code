    var cityCache = new Dictionary<string, Dictionary<string, int>>();
    var countryCode = "";
    var cityCode = "";
    var id = x;
    
    public static IsCityValid(City c)
    {
         return
             cityCache.ContainsKey(c.CountryCode) &&
             cityCache[c.CountryCode].ContainsKey(c.CityCode) &&
             cityCache[c.CountryCode][c.CityCode] == c.Id;  
    }
