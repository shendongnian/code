    foo.UserName = "10-1685";
    string[] names = foo.UserNameSeparated;
    // names[0] = "10";
    // names[1] = "1685";
    foo.UserNameSeparated = new string[] { "15", "42" };
    // foo.UserName = "15-42"
