    [OperationContract]
    [WebGet(UriTemplate = "TestMethod")]
    string TestMethod();
    public string TestMethod()
    {
        byte[] data = GetData();
        return Convert.ToBase64String(data);
    }
