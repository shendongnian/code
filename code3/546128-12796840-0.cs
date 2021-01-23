    IEnumerable<dynamic> userInfo = (from user in users
                                     where user.id equals userId
                                     select new { user.name, user.id /*, ...*/ }).ToList();
    foreach (dynamic user in userInfo)
    {
        Console.WriteLine(user.name);
        Console.WriteLine(user.id);
        //...
    }
