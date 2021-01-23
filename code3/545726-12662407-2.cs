    YourUpdateMethod(UserProfileModel model)
    {
        using(YourContext ctx = new YourContext())
        { 
            User user = new User { Id = model.Id } ;   /// stub model, only has Id
            ctx.Users.Attach(user); /// track your stub model
            ctx.Entry(user).CurrentValues.SetValues(model); /// reflection
            ctx.SaveChanges();
        }
    }
