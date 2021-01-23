    namespace WcfService3
    {
        public class Service1 : IService1
        {
            [WebInvoke(Method = "GET", 
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "data/{user}/{pass}")]
            public Data GetData(string user, string pass)
            {
                Data UserData = new Data()
                {
                    Username = user,
                    Password = pass
                };
    
                return UserData;
            }  
        }
    }
