    [ServiceContract]
    public class WCFTestServer
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/PutMessageGET/{str}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string PutMessageGET(string str)
        {
            return String.Join("", str.Reverse());
        }
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/PutMessagePOSTUriTemplate/{str}", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string PutMessagePOSTUriTemplate(string str)
        {
            return String.Join("", str.Reverse());
        }
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle=WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string PutMessagePOSTWrappedRequest(string str)
        {
            return String.Join("", str.Reverse());
        }
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public string PutMessagePOSTBare(string str)
        {
            return String.Join("", str.Reverse());
        }
    }
