    namespace MyHostApi
    {
        [ServiceContract]
        public interface IMyHostApi
        {
    
            [OperationContract]
            [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "WhateverYouWant/HelloWorld/{name}")]
            string HelloWorld(string format, string name);
        }
    }
