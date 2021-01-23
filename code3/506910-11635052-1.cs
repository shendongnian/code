    List<Entry> elist = new List<Entry>();
    for (int i = 0; i < list.Count; i += 3)
    {
        var ent = new Entry() { Name    = list[i],
                                Gender  = list[i+1],
                                Country = list[i+2]};
        elist.Add(ent);
    }
