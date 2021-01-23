    public IEnumerable<Item<T>> FilteredItems
    {
        get
        {
            if (UsePredicate) {
                return ItemsList
                    .Select((item, i) => new Item<T>(ItemsList, i))
                    .Where(item => SomeCondition(item.Value));
            }
            return ItemsList.Select((item, i) => new Item<T>(ItemsList, i));
        }
    }
