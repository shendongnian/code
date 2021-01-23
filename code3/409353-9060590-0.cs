     [ WebMethod(Description="Per session Hit Counter",EnableSession=true)]
    public void UpdatedData(string CountryName, string CountryCode, string City, string RegionCode, string RegionName) 
    {
    Chat ch = new Chat(); 
    ch.CountryName = CountryName; 
    ch.CountryCode = CountryCode; 
    ch.City = City; ch.RegionCode = RegionCode; 
    ch.RegionName = RegionName; 
    Session["Chat"] = ch;
    }
