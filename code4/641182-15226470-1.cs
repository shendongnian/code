    using Microsoft.AspNet.SignalR;
    namespace MyWebApplication
    {
        public class Chat : Hub
        {
            public void Send(string message)
            {
                //Call the addMessage method on all clients     
                var c = GlobalHost.ConnectionManager.GetHubContext("Chat");
                c.Clients.All.addMessage(message);
            }
        }
    }
