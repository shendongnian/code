    namespace ADM
    {
        [ServiceContract]
        public interface IRestServiceImpl
        {
            [OperationContract]
            [WebInvoke(Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "forms/")]
            List<FormContract> allForms();
        }
    }
