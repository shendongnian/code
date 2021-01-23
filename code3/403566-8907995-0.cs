    UserInfo Character = db.UserInfoes.SingleOrDefault(a => a.Username == user);
    if (Character == null || Character.Username == null || Character.Username.Length == 0)
    {
        //do stuff
    }
