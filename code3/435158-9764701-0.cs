    using(IMyContext context = new MyContext())
    {
        IQueryable<User> query = context.RetrieveUsersByRole("Software Developers");
        List<User> developerUsers = query.ToList();
        foreach(User dev in developerUsers)
            dev.Salary = 100000000;
        context.SaveChanges()
    }
