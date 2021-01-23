    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string ItemsForDictionary(string data)
    {
        Dictionary<String, String> newDict = ConvertDataToDictionary(data);
    }
