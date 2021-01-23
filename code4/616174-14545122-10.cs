    if(entries.Count >= 50)
    {
        testEntries = entries;
        int x = 0;
        int pivot = (entries.Count / 2);
        //Copy
        for (x = pivot; x < entries.Count; x++)
        {
            testEntries[x - pivot] = testEntries[x];
        }
        //Remove
        for (x = pivot; x < entries.Count; x++)
        {
            testEntries.RemoveAt(x);
        }
        entries = testEntries;
    }
