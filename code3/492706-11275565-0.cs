    public IEnumerable<int> FilteredIndexes
    {
        get
        {
            if (UsePredicate) {
                return ItemsList
                    .Select((item, i) => i)
                    .Where(i => SomeCondition(ItemsList[i]));
            }
            return ItemsList.Select((item, i) => i);
        }
    }
