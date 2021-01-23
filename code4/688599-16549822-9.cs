    public static IDictionary<string, string> ToDictionary(this NameValueCollection col)
    {
        IDictionary<string, string> dict = new Dictionary<string, string>();
        foreach (var k in col.AllKeys)
        { 
            dict.Add(k, col[k]);
        }  
        return dict;
    }
