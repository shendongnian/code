    public void ChangeUserName(List<UserData> users, int userId, string newName)
    {
         var user = users.Single(x=> x.UserId == userId);
         user.Name = newName;  // here you are changing the Name value of UserData objects, which is still part of the list
    }
