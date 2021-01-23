    // this is your base interface
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract(Action = "http://tempuri.org/LoginService/Login", Name = "Login")]
        bool Login(string userName, string password);
    }
    
    [ServiceContract]
    public interface IExtendedInterface : ILoginService
    {
        [OperationContract(Action = "http://tempuri.org/LoginService/Ping", Name="Ping")]
        DateTime Ping();
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            IExtendedInterface channel = null;
            EndpointAddress endPointAddr = new EndpointAddress("http://localhost/LoginService");
            BasicHttpBinding binding = new BasicHttpBinding();
    
            channel = ChannelFactory<IExtendedInterface>.CreateChannel(binding, endPointAddr);
    
            if (channel.Login("test", "Test"))
            {
                Console.WriteLine("OK");
            }
            DateTime dt = channel.Ping();
    
            Console.WriteLine(dt.ToString());
    
        }
    }
