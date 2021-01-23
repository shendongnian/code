    public string UpdateUserDetails(User user)
    {
        string info;
        try
        {
            User uUser = context.Users.FirstOrDefault(x => x.Id == user.Id);
            uUser.Category = user.Category;
            uUser.Email = user.Email;
            uUser.FullName = user.FullName;
            uUser.Login = user.Login;
            context.SaveChanges();
            // detach the entity after saving it
            Context.Entry(uUser).State = System.Data.EntityState.Detached;
            // I noticed that you don't "catch" the identity after saving.
            // Your application might not need this at the moment, but it's still
            // a good idea to do so anyway.
            user.Id = uUser.Id;
            info = "success";
        }
        catch (Exception err)
        {
            info = err.Message;
        }
        return info;
    }
