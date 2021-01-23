    if(entries.Count >= 50)
    {
        testEntries = entries;
        int x = 0;
        for (x = 0; x < (entries.Count / 2); x++)
        {
            testEntries.RemoveAt(0); // <--- Always removing the first item
        }
        //No need
        /*for (x = 0; x < (entries.Count); x++)
        {
            testEntries.Add(entries[entries.Count / 2]);
        }*/
        entries = testEntries;
    }
