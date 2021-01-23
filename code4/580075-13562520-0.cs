    public Dictionary<string, Object.Test> PostSalesOrderData(string data)
    {
        var jss = new JavaScriptSerializer();
        var dict = jss.Deserialize<Dictionary<string,dynamic>>(data);
        ...
    }
