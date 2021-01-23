    public override string[] GetUsersInRole(string roleName)
    {
        using (MembershipDb db = new MembershipDb())
        {
            return db.Roles
               .Where(r => r.Name == roleName)
               .SelectMany(r => r.Users, (r, s) => s.User.UserName).ToArray();
        }
    }
