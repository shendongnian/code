    if(entries.Count >= 50)
    {
        testEntries = entries;
        int x = 0;
        int pivot = (entries.Count / 2) + 1; //+1 because it may be odd
        //Copy
        for (x = 0; x < pivot; x++)
        {
            if ((x + pivot) < entries.Count) //because it may be even and we added 1
            {
                testEntries[x] = testEntries[x + pivot];
            }
        }
        //Remove
        for (x = pivot; x < entries.Count; x++)
        {
            testEntries.RemoveAt(x);
        }
        entries = testEntries;
    }
