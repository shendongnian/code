    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,UriTemplate = "getGroupInfo/{PersonId}")]
    string getGroupInfo(string PersonId)
    {
        return getGroupInfo(PersonId, null);
    }
    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,UriTemplate = "getGroupInfo/{PersonId}/{GroupId}")]
    string getGroupInfo(string PersonId, string GroupId)
    {
    }
