    public class ContosoChatHub : Hub
    {
        public Task JoinGroup(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }
        public Task LeaveGroup(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }
        public void Send(string message)
        {
            // Call the addMessage method on all clients in group
            Clients.Group("recievers").addMessage("Group Message " + message);
        }
    }
