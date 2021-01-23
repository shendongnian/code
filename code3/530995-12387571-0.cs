    [WebMethod]
    public static string GetJsonData()
    {
        string jsonData = String.Empty;
        foreach(var dataItem in objEntireData.Items)
        {
             //  jsonData +=  
        }
       return new JavaScriptSerializer().Serialize(result);
    } 
