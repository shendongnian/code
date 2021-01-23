    public int GetUserCount(string alpha, string search, bool byEmail, int startRowIndex, int maximumRows)
    {
        var users = Membership.GetAllUsers().Cast<MembershipUser>();
        if (alpha != null && search == null)
        {
            users = users.Where(x => x.UserName.StartsWith(alpha) == true);
        }
        else if (search != null && !byEmail)
        {
            users = users.FindUsersByName(search).Cast<MembershipUser>();
        }
        else
        {
            users = users.FindUsersByEmail(search);
        }
        return users.Count();
    }
