    public IEnumerable<ItemChange<T>> GetChangeHistory<T>(int numberOfChanges) where T : MyBase
    {
        IEnumerable<ItemChange<MyBase>> obj1Changes = GetChanges<Object1>().Select(i => new ItemChange<MyBase>(){ When = i.When, Who = i.Who, NewState = i.NewState, OldState = i.OldState });
        IEnumerable<ItemChange<MyBase>> obj1Changes = GetChanges<Object2>().Select(i => new ItemChange<MyBase>(){ When = i.When, Who = i.Who, NewState = i.NewState, OldState = i.OldState });
        return obj1Changes.Concat(obj2Changes).OrderByDescending(r => r.When).Take(numberofChanges);
    }
