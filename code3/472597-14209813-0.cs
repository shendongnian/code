    public static List<TwitterUser> GetFollowers(this TwitterService svc)
    {
        List<TwitterUser> ret = new List<TwitterUser>();
        var followers = svc.ListFollowers(-1);
        ret.AddRange(followers);
        while (followers.NextCursor != null && followers.NextCursor.Value > 0)
        {
            followers = svc.ListFollowers(followers.NextCursor.Value);
            ret.AddRange(followers);
        }
        return ret;
    }
