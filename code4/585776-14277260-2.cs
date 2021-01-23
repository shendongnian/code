    static void Main(string[] args)
    {
        Server();
    }
    
    static void Server()
    {
        Console.WriteLine("Server started...");
        var httpChannel = new HttpChannel(9998);
        ChannelServices.RegisterChannel(httpChannel);
        RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("Server.Program+SomeClass"), "SomeClass", WellKnownObjectMode.SingleCall);
        Console.WriteLine("Press ENTER to quit");
        Console.ReadLine();
    }
    
    public interface ISomeInterface
    {
        string GetString();
    }
    
    public class SomeClass : MarshalByRefObject, ISomeInterface
    {
        public string GetString()
        {
            const string tempString = "ServerString";
            Console.WriteLine("Server string is sended: {0}", tempString);
            return tempString;
        }
    }
