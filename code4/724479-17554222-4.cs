    public static IEnumerable<T> TakeFromEnd<T>(this IEnumerable<T> items, int n)
    {
        var arry = new T[n];
        int i = 0;
        foreach(var x in items)
        {
            arry[i++ % n] = x;
        }
        if (i < n)
        {
            n = i;
            i = 0;
        }
        for (int j = 0; j < n; j++)
        {
            yield return arry[(i + j) % n];
        }
    }
    var nodes = doc.Descendants("LogInfo");
    foreach (var node in nodes.TakeFromEnd(n))
    {
        ...
    }
