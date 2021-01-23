    void DoSomething(ItemType item, OtherType other) {
    }
    void YourFunction(IEnumerable<ItemType> items, IEnumerable<OtherType> others) {
        
        foreach (var otherItem in others) {
            var localOtherItem = otherItem;
            Parallel.ForEach(items, item => DoSomething(item, localOtherItem));
        }
    }
