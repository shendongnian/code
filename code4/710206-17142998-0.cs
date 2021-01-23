    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(BodyStyle=WebMessageBodyStyle.Bare, RequestFormat=WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Json)]
        string EchoWithGet(string s);
    
        [OperationContract]
        [WebInvoke(BodyStyle=WebMessageBodyStyle.Bare, RequestFormat=WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Json)]
        string EchoWithPost(string s);
    }
    
    public class Service : IService
    {
        public string EchoWithGet(string s)
        {
            return "You said " + s;
        }
    
        public string EchoWithPost(string s)
        {
            return "You said " + s;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri("http://localhost:8000/"));
            ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
            ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            sdb.HttpHelpPageEnabled = false;
            host.Open();
            Console.WriteLine("Service is running");
            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
            host.Close();
        }
    }
