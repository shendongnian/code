    public class Chat : Hub
    {
        public void send(string message)
        {
            Clients.addMessage(message);
        }
    
        public void securesend(string message)
        {
            if (this.Context.User.Identity.IsAuthenticated)
            {
                // secure send.
            }
        }
    }
