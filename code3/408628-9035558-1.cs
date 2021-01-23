    public PartialViewResult SearchUserByName(string userName)
    {
         List<User> users = // code to search users by name
         return PartialView("_users", users);
    }
