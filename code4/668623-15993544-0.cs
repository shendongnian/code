    List<Co> coll = new List<Co>();
    Co c = new Co();
    c.Id = 1;
    c.Title = "A";
    coll.Add(c);
    c = new Co(); // HERE
    c.Id = 2;
    c.Title = "B";
    coll.Add(c);
    List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
    list.Add(new KeyValuePair<int, int>(1, 2));
    list.Add(new KeyValuePair<int, int>(1, 3));
    list.Add(new KeyValuePair<int, int>(1, 1));
    list.Add(new KeyValuePair<int, int>(2, 1));
