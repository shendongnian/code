    public User ValidateUser(string applicationNamespace,
        string username, string password)
    {
        return context.ApplicationConfigs
            .Where(a => a.Namespace == applicationNamespace)
            .Select(a => a.Users
                .Where(u => u.Username.ToLower() == username &&
                    u.Password == password)
                .FirstOrDefault())
            .FirstOrDefault();
    }
