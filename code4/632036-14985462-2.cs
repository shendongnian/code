    public bool Any<T>(IEnumerable<T> list)
    {
        using (var enumerator = list.GetEnumerator())
        {
            return enumerator.MoveNext();
        }
    }
