    var names = new List<string>(new string[] { "aa", "bb", "xx" });
    for(int i = 0; i < 3; i++)
    {
        var a = new Application { Name = names[i] };
        applications.Add(a);
    }
