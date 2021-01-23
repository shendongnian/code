    if(entries.Count >= 50)
    {
        testEntries = entries;
        int x = 0;
        while (entries.Count > 25)
        {
            testEntries.RemoveAt(0);
        }
        entries = testEntries;
    }
