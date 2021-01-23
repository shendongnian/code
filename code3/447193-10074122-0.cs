    namespace ADM
    {
        [ServiceContract]
        public interface IRestServiceImpl
        {
            [OperationContract]
            [WebInvoke(Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Wrapped,
                UriTemplate = "forms/")]
            List<FormContract> allForms();
        }
    }
