    using (var enumerator = enumerable.GetEnumerator())
    {
        if (!enumerator.MoveNext())
        {
            throw // some kind of exception;
        }
        var value = enumerator.Current;
        while (enumerator.MoveNext())
        {
            // Do something with value and enumerator.Current
        }
    }
