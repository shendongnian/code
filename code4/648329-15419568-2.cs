    var dic = new Dictionary<string, object>();
    foreach(var obj in version1.Cache)
    {
        foreach(var newObj in version2.Cache)
        {
            //snip -- do stuff to check equality
            dic.Add(....);
        }
    }
