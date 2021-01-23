    using (var context = new AdnLineContext())
    {
        context.Users.Add(user1);
        context.Users.Add(user2);
        context.Users.Add(user3);
        user1.Friends = new List<User>();
        user1.Friends.Add(user2);
        user3.FromWhomIsFriend.Add(user1);
        context.SaveChanges();
    }
