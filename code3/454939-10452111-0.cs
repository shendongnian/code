    public class Program
        {
            public static void Main(string[] args)
            {
                Uri baseAddress = new Uri("https://"+Environment.MachineName+":54321/hello");
                using (ServiceHost host = new ServiceHost(typeof(HelloWorldService), baseAddress))
                {                
                    WebHttpBinding web = new WebHttpBinding();
                    web.Security.Mode = WebHttpSecurityMode.Transport;                
                    host.AddServiceEndpoint(typeof(IHelloWorldService), web, "").Behaviors.Add(new WebHttpBehavior());                                
                    host.Credentials.ServiceCertificate.Certificate = (X509Certificate2)GetX509Certificate();                               
                    host.Open();
                    Console.WriteLine("The service is ready at {0}", baseAddress);
                    Console.WriteLine("Press <Enter> to stop the service.");
                    Console.ReadLine();                
                    host.Close();
                }
            }
    
            private static X509Certificate GetX509Certificate()
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.OpenExistingOnly);
                X509Certificate certificate = null;
                X509Certificate2Collection cers = store.Certificates.Find(X509FindType.FindBySubjectName, "localhost", false);            
                if (cers.Count > 0)
                {
                    certificate = cers[0];
                }
                store.Close();
                return certificate;
            }
        }
    [ServiceContract]
        public interface IHelloWorldService
        {
            [WebGet(UriTemplate="SayHello/{name}")]
            string SayHello(string name);
        }
    
        public class HelloWorldService : IHelloWorldService
        {
            public string SayHello(string name)
            {
                return string.Format("Hello, {0}", name);
            }
        }
