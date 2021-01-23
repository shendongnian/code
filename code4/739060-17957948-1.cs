        var user1 = context.Users.Create();
        //...
        var user2 = context.Users.Create();
        //...
        var user3 = context.Users.Create();
        //...
        context.Users.Attach(user1);
        context.Users.Attach(user2);
        context.Users.Attach(user3);
        user1.Friends.Add(user2);
        user3.Friends.Add(user1);
        // Lazy loading will run twice here based on the `UserId` which is 0
        // and returns nothing, but the Friends collection will be initialized
        // as empty collection
        // This MUST be AFTER accessing the Friends collection
        context.Users.Add(user1);
        context.Users.Add(user2);
        context.Users.Add(user3);
        context.SaveChanges();
