    public static User CreateUser(string firstName, string sirname)
    {
        User newUser = new User();
        newUser.FirstName = firstName,
        newUser.Surname = sirname,
        newUser.AddedDateTime = DateTime.Now,
        newUser.ModifiedDateTime = DateTime.Now
        return newUser;
    };
