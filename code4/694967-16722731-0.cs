    public User ValidateUser(string applicationNamespace, string username, string password)
    {
       var applicationConfig = GetApplicationConfig(applicationNamespace);
       if (applicationConfig != null)
       {
       return applicationConfig.Users.FirstOrDefault(u => u.Username.ToLower() == username && u.Password == password);
       }
    }
