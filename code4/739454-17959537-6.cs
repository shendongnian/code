    // we are in an ASP.NET MVC controller action here
    using (var context = new MyContext())
    {
        string userName = User.Identity.Name;
        int? userId = context.UserProfiles
            .Where(u => u.Name == userName)
            .Select(u => (int?)u.UserId)
            .SingleOrDefault();
        if (userId.HasValue)
        {
            var newJogger = new Jogger { JoggerId = userId.Value };
            context.Joggers.Add(newJogger);
            context.SaveChanges();
        }
    }
