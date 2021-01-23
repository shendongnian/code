    public static UserProfile GetUserProfile(Guid userID)
    {
        UserProfile oProfile = null;
        using (var context = new MyEntities())
        {
            oProfile = (from c in context.UserProfiles where c.UserID == userID select c).FirstOrDefault();
        }
        return oProfile;
    }
