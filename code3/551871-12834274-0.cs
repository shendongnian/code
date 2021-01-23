    namespace WebApplication1
    {
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            [WebGet(UriTemplate = "add?a={a}&b={b}", 
                    BodyStyle = WebMessageBodyStyle.Bare, 
                    ResponseFormat = WebMessageFormat.Json)]
            int Add(int a, int b);
        }
    }
