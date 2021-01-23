    [HubName("messageHub")]
        public class MessagesHub : Hub
        {
            public void AddMessage(string htmlstring)
            {
                Clients.addMessage(htmlstring);
            }
        }
