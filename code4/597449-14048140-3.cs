    [WebMethod]
    public static void AddNewRecord(object startPrt)
    {
        var dict = new Dictionary<string, object>();
        foreach (Dictionary<string, object> pair in (Array)startPrt)
            dict.Add((string)pair["key"], pair["value"]);
    }
