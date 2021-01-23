    public bool Remove(T item) 
    { 
        var old = hashSet;
        var newHashSet = new HashSet<T>(old); 
        var removed = newHashSet.Remove(item); 
        var current = Interlocked.CompareExchange(ref hashSet, newHashSet, old);
        if (current != old)
        {
           // failed... throw or retry...
        }
        return removed; 
    } 
