    IEnumerable<T> GetItems()
    {
        if (someCondition.Which.Yields.One.Item)
        {
            return Enumerable.Repeat(MyRC, 1);
        }
        else
        {
            // You *could* just return myList, but
            // that would allow callers to mess with it.
            return myList.Select(x => x);
        }
    }
