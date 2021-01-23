    [OperationContract]
        [WebInvoke(UriTemplate = "/Login", Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)] 
        [return: MessageParameter(Name = "success")]
        MyDictionary<string, string> TestMe(string param1, string param2);
