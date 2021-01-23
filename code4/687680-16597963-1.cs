    public Task Join()
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            var username = Context.User.Identity.Name;
            return Groups.Add(Context.ConnectionId, username);
        } 
        else
        {
            // a do nothing task???? 
            return Task.Factory.StartNew(() =>
            {
                // blah blah 
            });
        }   
    }
    
