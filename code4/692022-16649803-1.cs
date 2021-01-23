    List<UserData> userData = new List<UserData>();
    Ektron.Cms.API.User.User user = new Ektron.Cms.API.User.User();
    long groupId = Id; //your group id
    foreach (UserData u in user.GetUsers(groupId, "username")) //group id + sort by field
    {
        userData.Add(user.GetUser(u.Id));
    }
    return userData;
