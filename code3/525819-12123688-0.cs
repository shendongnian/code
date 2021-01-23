    public static string TestFunction(IDictionary<string, object> dict)
    {
        var ret = "";
        foreach (var item in dict)
        {
            ret += item.Key + item.Value.ToString();
        }
        return ret;
    }
