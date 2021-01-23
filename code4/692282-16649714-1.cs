    SortedDictionary<string,int> MyCache = new SortedDictionary<string, int>();
    string strKey = "NewResult";
    if (MyCache.ContainsKey(strKey))
    {
        MyCache[strKey] = MyCache[strKey] + 1;
    }
    else
    {
        MyCache.Add(strKey, 1);
    }
