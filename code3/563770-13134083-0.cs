    var userList = new List<string>();
    userList.Add("TestUser1|pre1");
    userList.Add("TestUser2|pre2");
    foreach (var user in userList)
    {
        var userParts = user.Split(new[] { '|' });
        var userName = userParts[0];
        var prefix = userParts[1];
        Console.WriteLine(string.Format("{0}{1}", prefix, userName));
    }
