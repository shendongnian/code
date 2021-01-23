    // use his generator method
    public IEnumerable<String> generator()
    {
        ...
    }
    ....
    int counter = 0;
    foreach (String item in generator())
    {
        // compute indexes
        int ix_list3 = counter % List3.Count;
        int ix_list2 = (counter / List3.Count) % List2.Count;
        int ix_list1 = (counter / (List3.Count * List2.Count));
        // do something with item and indexes
        ++counter;
    }
