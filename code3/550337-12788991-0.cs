    var firstList = 
        Listener
            .Clients
            .Where(c => c.Value.Authenticated).Select(c => c.Value.UserID).ToList();
    var secondList = 
        Listener
            .Clients
            .Where(c => !c.Value.Authenticated).Select(c => c.Value.UserID).ToList();
