    public static List<string> GetCountryData()
    {
        List<string> lstCountries = new List<string>();
        var countryData = yourDBContext.Database.SqlQuery<string>("SPROC_GetCountryData");
        if(countryData.Any())
        {
            lstCountries = countryData.ToList<string>();
        }
        return lstCountries;
    }
