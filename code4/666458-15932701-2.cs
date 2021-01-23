    public Mock<HttpRequestBase> GetRequestMock(Dictionary<string, object> queryParms)
    {
        var queryString = new NameValueCollection();
        foreach (KeyValuePair<string, object> kvp in queryParms)
        {
            queryString[kvp.Key] = Convert.ToString(kvp.Value);
        }
        ...
    }
