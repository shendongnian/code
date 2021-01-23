    static string[] Countries = new string[] { "AF", "BD", "CA", "IN", "IR", "RO", "AN", "CY", "IL", "PH" };    
    private bool CheckMemberCountry(string country)
    {       
       return Countries.Contains(country);
    }
