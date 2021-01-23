    namespace MyProject.HelloWorld {
        [ServiceContract]
        public interface IHelloWorld {
            [OperationContract]
            [WebGet(UriTemplate="", ResponeFormat=WebMessageFormat.Xml)]
            HelloWorldResult helloWorld();
        }
        
        [DataContract()]
        public class HelloWorldResult {
            [DataMember]
            public String Message {get; set;}
        }
    }
