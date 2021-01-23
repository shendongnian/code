    T x;
    using (var enumerator = y.GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            x = enumerator.Current;
            // ...
        }
    }
