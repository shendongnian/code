    [WebMethod(EnableSession=true), ScriptMethod]
    public  static string GetProcessed(string correlationKey)
    {
        var dictionary = Application["ProcessedQueue"] as Dictionary<string, int>;
        if (dictionary == null || !dictionary.ContainsKey(correlationKey)) { return "0"; }
        return dictionary[correlationKey].ToString();
    }
