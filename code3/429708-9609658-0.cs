    public void SaveUser(Domain.Entities.User user)
    {
        if (user.UserId == 0)
        {
            context.Users.Add(user);
        }
        else
        {
            var userInDb = context.Users.Single(u => u.UserId == user.UserId);
            if (user.profileImage == null)
                user.profileImage = userInDb.profileImage;
            context.Entry(userInDb).CurrentValues.SetValues(user);
        }
        context.SaveChanges();
    }
