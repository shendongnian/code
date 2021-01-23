    void DealWithIt<T,V>(IEnumerable Values)
    {
    foreach (object item in Values)
    {
        var dictionary = item as Dictionary<T,V>;
        if (dictionary != null)
        {
            DoStuff<T,V>(dictionary);
        }
    }
