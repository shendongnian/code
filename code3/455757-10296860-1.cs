    public override IEnumerator<T> GetEnumerator()
    {
        IEnumerator<T> enumerator = base.GetEnumerator();
        while (enumerator.MoveNext())
        {
            T item = enumerator.Current;
            // Some logic here
            yield return item;
            // Some more logic here
        }
    }
