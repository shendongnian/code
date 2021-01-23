    public Dictionary(int capacity, IEqualityComparer<TKey> comparer)
    {
        if (capacity < 0)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity);
        }
        if (capacity > 0)
        {
            this.Initialize(capacity);
        }
        this.comparer = (comparer ?? EqualityComparer<TKey>.Default);
    }
