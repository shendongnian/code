    [WebMethod]
    [ScriptMethod]
    public static string save(string parameter, string name)
    {
        PerformSave(name, parameter);
        return "Data Saved!";
    }
