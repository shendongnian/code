    public static List<User> SearchUser(List<int> roleIDs)
    {
        using (var db = new DBContext())
        {
            if (roleIDs.Count == 0)
            {
                 return db.Users.ToList();
            }
    
            var users = (
                from u in db.Users
                join ur in db.User_Role
                    on u.UserID equals ur.UserID
                join r in roleIDs
                    on ur.RoleID equals r
                select u
                ).Distinct().ToList();
    
            return users;
        }
    }
