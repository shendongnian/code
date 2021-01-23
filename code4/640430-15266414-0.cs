    public class ChatHub : Hub
    {
         public override Task OnDisconnected()
         {
             Broadcaster.Disconnected(Context.ConnectionId);
             return base.OnDisconnected();
         }
    }
