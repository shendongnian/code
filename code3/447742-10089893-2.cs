    List<int> list;
    if (!dictionary.TryGetValue("foo", out list))
    {
        list = new List<int>();
        dictionary.Add("foo", list);
    }
    list.Add(2);
