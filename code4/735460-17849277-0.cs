    [WebMethod]
    public static string save (object data)
    {
    //String s1 = data.ToString();
    //Dictionary<string, object> tmp = (Dictionary<string, object>)data;
    //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
    //MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));
    //string obj = (string)ser.ReadObject(ms);
    string s2 = data.ToString();
    GC.GClass g = new GC.GClass();
    g.Save(s2);
    return s2;
    }
