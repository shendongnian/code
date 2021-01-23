    public static IQueryable<int> GetUserTags(int userId)
    {
        return database.Usr_Tags
            .Where(u => u.User_id == userId)
            .Select(u => u.Tag_id);
    }
    
    var commonTags = GetUserTags(userID1).Intersect(GetUserTags(userID2));
