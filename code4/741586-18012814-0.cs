    public List<User> GetAllUsers()
    {
        using (var context = new AdnLineContext())
        {
            var users = (from u in context.Users
                        select u).Tolist();
    
        }
    
        return users 
    }
