    public Task Join()
    {
        string username = Context.User.Identity.Name;
        //find group based on username
        string group = getGroup(username)
        return Groups.Add(Context.ConnectionId, group);
    }
