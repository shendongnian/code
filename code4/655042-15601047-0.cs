    public void seedData()
    {
        const string[] names = new string[] { "xx", "bb", "xx" };
        foreach (string name in names)
            applications.Add(new Application { Name = name });
    }
