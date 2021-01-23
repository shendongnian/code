    public static List<Folder_User> GetAllFolder_USer(User user, DataModel dbContext)
    {
        var query = dbContext.Folder_User.
                              Include(f => f.MasterDoc).
                              Where(f => f.User.Id == user.Id);
        return query.ToList();
    }
