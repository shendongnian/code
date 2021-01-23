    public static List<User> SearchUser(List<int> roleIDs)
    {
        using (var db = new DBContext())
        {
            if (roleIDs.Count == 0)
            {
                 return db.Users.ToList();
            }
    
            var users = db.Users.Where(u => u.Roles.Any(r => roleIDsContains(r.Id)))
                .Distinct().ToList();
    
            return users;
        }
    }
