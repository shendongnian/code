    [WebMethod]
    public string[] GetCountries(string prefixText)
    {
         // .....
    
         return CountryNames.ToArray();
    }
