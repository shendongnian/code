    public static User CreateUser(string firstName, string sirname, string otherdata)
    {
        User newUser = new User();
        newUser.FirstName = firstName,
        newUser.Surname = sirname,
        newUser.AddedDateTime = DateTime.Now,
        newUser.ModifiedDateTime = DateTime.Now,
        newUser.SomeField = otherdata,
        newUser.SomeOtherField = otherdata
        return newUser;
    };
