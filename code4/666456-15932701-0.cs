    public Mock<HttpRequestBase> GetRequestMock(Dictionary<string, object> queryParms)
    {
        var queryString = new NameValueCollection();
        foreach (KeyValuePair kvp in queryParms)
        {
            queryString[kvp.Key] = kvp.Value;
        }
        ...
    }
