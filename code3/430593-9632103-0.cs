    public User GetUser(string username)
    {
        if (String.IsNullOrEmpty(username))
            throw ArgumentNullException("username");
        return this.users[username];
    }
