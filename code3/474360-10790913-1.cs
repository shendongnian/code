    if (a == b)
    {
        var tbl = new HashTable();
        tbl.Add(a, "Test");
        var s = tbl[b];
        Debug.Assert(s.Equals("Test"));
    }
