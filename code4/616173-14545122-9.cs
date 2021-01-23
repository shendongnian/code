    if(entries.Count >= 50)
    {
        testEntries = entries;
        while (entries.Count > 25)
        {
            testEntries.RemoveAt(0);
        }
        entries = testEntries;
    }
