    public IEnumerable<ItemChange<T>> GetChangeHistory<T>(int numberOfChanges) where T : MyBase
    {
        IEnumerable<ItemChange<MyBase>> obj1Changes = GetChanges<Object1>().Select(i => (ItemChange<MyBase>)i);
        IEnumerable<ItemChange<MyBase>> obj1Changes = GetChanges<Object2>().Select(i => (ItemChange<MyBase>)i);
        return obj1Changes.Concat(obj2Changes).OrderByDescending(r => r.When).Take(numberofChanges);
    }
