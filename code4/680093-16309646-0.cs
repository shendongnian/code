    var toRemove = new Dictionary<int, string>() //whatever type it is
    var dictEnum = dictObj.GetEnumerator();
    while (dictEnum.MoveNext())
    {
        Parallel.ForEach(dictObj, pOpt, (KVP, loopState) =>
        {
            toRemove.Add(KVP);
        });
    }
    foreach (var item in toRemove)
    {
        dictObject.Remove(item.Key);
    }
