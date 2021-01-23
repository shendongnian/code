    [WebMethod]
    public static string GetSecondStageData(object sentobj)
    {
        var x = sentobj;
        return DateTime.Now.ToString();
    }
