    for (int index = 0; index < 5; index++)
    {
        int k = key[index];
        int v = val[index];
        List<long> items;
        if (testList.TryGetValue(k, out items))
        {
            items.Add(v);
        }
        else
        {
            testList.Add(k, new List<long> { v });
        }
    }
