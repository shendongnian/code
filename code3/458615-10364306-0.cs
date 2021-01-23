    public List<string> GetCategories()
    {
        List<string> cats = new List<string>();
        SqlDataReader myreader = null;
        ...
        while (myreader.Read())
            cats.Add((string)myreader["members"]);
        ...
        return cats;
    }
