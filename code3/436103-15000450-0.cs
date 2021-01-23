    public class Chat : Hub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
     
        public override Task OnDisconnected()
        {
            return base.OnDisconnected();
        }
     
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
