    [ServiceContract]
    public class Service
    {
        [WebGet(UriTemplate = "ReturnData?s={s}&callback={callbackFunctionName}")]
        public Stream EchoWithGet(string s, string callbackFunctionName)
        {
            string jsCode = callbackFunctionName + "({\"Status\":\"OK\"});";
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/javascript";
            return new MemoryStream(Encoding.UTF8.GetBytes(jsCode));
        }
    }
