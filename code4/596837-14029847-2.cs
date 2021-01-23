    [WebMethod]
    public static string GetSecondStageData(object results)
    {
        var x = results;
        return DateTime.Now.ToString();
    }
    
