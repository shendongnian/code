    // Option 1
    var r = from message in Session.Query<Message>()
            from userid in message.AssociatedUsers
            group userid by userid into g
            select new { UserID = g.Key, Count = g.Count() };
    
    // Option 2
    string userId = null;
    var r = Session.QueryOver<Message>()
        .JoinQueryOver<string>(m => m.AssociatedUsers, () => userId)
        .SelectList(list => list
            .SelectGroup(() => userid)
            .Select(Projections.Count()))
        .List<object[]>();
