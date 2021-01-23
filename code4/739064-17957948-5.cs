        var user1 = context.Users.Create();
        //...
        var user2 = context.Users.Create();
        //...
        var user3 = context.Users.Create();
        //...
        user1.Friends = new List<User>();
        user1.Friends.Add(user2);
        user3.Friends = new List<User>();
        user3.Friends.Add(user1);
        context.Users.Add(user1);
        context.Users.Add(user2);
        context.Users.Add(user3);
        context.SaveChanges();
