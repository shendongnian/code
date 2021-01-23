      [HubName("messageHub")]
            public class MessagesHub : Hub
            {
                public void SendMessage(string htmlstring)
                {
                    Clients.addMessage(htmlstring);
                }
            }
