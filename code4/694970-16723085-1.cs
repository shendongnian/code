    public User ValidateUser(string applicationNamespace,
        string username, string password)
    {
        return context.Users
            .FirstOrDefault(u =>
                u.ApplicationConfigs.Any(a => a.Namespace == applicationNamespace) &&
                u.Username.ToLower() == username && u.Password == password);
    }
