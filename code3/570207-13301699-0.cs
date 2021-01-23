    public bool IsValidUser(string userName, string passWord)
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        return db.Users.Any(u => u.name == userName && u.password == passWord);
    }
