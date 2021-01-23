    using (var context = new MyContext())
    {
        string userName = User.Identity.Name;
        UserProfile userProfile = context.UserProfiles
            .Where(u => u.Name == userName)
            .SingleOrDefault();
        if (userProfile != null)
        {
            userProfile.Jogger = new Jogger();
            // I believe you don't need to set the JoggerId key now,
            // I'm not sure though
            context.SaveChanges();
            // Change tracking recognizes the new Jogger
            // no context.Joggers.Add is required
        }
    }
