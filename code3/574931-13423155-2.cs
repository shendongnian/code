    public Model.User GetUser(string username)
    {
        return Context.Users.SingleOrDefault(u => 
           string.Compare(u.Username, username, true)) ?? Model.User.Null;
    }
