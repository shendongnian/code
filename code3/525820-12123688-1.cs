    public static string TestFunction(object obj)
    {
        var dict = new RouteValueDictionary(obj);
        var ret = "";
        foreach (var item in dict)
        {
            ret += item.Key + item.Value.ToString();
        }
        return ret;
    }
