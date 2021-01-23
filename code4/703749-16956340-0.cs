    IDictionaryEnumerator enumerator = System.Web.HttpRuntime.Cache.GetEnumerator();
    while (enumerator.MoveNext())
    {
        string key = (string)enumerator.Key;
        object value = enumerator.Value;
        ...
    }
