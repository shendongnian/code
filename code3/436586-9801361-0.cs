     public interface IRestFulWCF
    {
        [OperationContract(Name = "MyMethod")]
        [WebInvoke(
            RequestFormat=WebMessageFormat.Json,
            UriTemplate="/Example",
            Method="POST",
            BodyStyle=WebMessageBodyStyle.WrappedResponse)
        ]
        public void MyMethod(string timestamp, string json)    }
