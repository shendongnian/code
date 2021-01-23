    public override bool ValidateUser(string username, string password)
    {
        var userRepo = DependencyResolver.Current.GetService<IUserRepository>();
        return userRepo.ValidateUser(username, password);
    }
