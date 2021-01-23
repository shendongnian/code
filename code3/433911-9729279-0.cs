    namespace WcfService1
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
        [ServiceContract]
        public interface HelloWorldService
        {
            [OperationContract]
            [WebGet(UriTemplate = "")]
    
            string HelloWorld();
        }
    }
