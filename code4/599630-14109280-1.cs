    public bool AllEqual<T>(IList<T> items)
    {
        // This could be a parameter if you want
        var comparer = EqualityComparer<T>.Default;
        for (int i = 1; i < items.Count; i++)
        {
            if (!comparer.Equals(items[0], items[i]))
            {
                return false;
            }
        }
    }
