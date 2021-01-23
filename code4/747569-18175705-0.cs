    public class NotificationsHub : Hub
    {
        public override Task OnConnected()
        {       
    		// Ensure that the group is added before completing OnConnected
           return Groups.Add(Context.ConnectionId, CurrentUser.UserId.ToString());
        }
    	
    	// Never remove from group in OnDisconnected, ConnectionId's are auto-removed from groups when they disconnect.
    }
