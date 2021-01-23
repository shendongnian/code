    /// <summary>
    /// Gets a user.
    /// </summary>
    /// <param name="username">Username</param>
    /// <returns>User instance</returns>
    public Model.User GetUser(string username)
    {
        return Context.Users.SingleOrDefault(u => 
           string.Compare(u.Username, username, true));
    }
