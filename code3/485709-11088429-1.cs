    [WebInvoke(UriTemplate = "HelloWorld", Method = "GET"), OperationContract]
    public Message HelloWorld()
    {
    	string jsonResponse = //Get JSON string here
    	return WebOperationContext.Current.CreateTextResponse(jsonResponse, "application/json; charset=utf-8", Encoding.UTF8);
    }
