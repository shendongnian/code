    [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "user_register/{uname}/{pwd}")]
            int user_register(string uname,string pwd);
        }
