    public bool IsValidUser(string userName, string passWord)
    {
        using (var db = ...)
        {
            ...
            return users.Any();
        }
    }
