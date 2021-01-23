    public class MyHub : Hub
    {
        internal static void SendMessage(string message)
        {
            var connectionManager = (IConnectionManager)AspNetHost.DependencyResolver.GetService(typeof(IConnectionManager));
            dynamic allClients = connectionManager.GetClients<MyHub>();
            allClients.messageRecieved(message);
        }
    
        ...
    }
