    public IEnumerable<TResult> VisitAllItems<TResult>(
        Func<Item, Result> visitfunction)
    {
        var result = new List<TResult>();
        lock (listLock)
        {
            foreach (Item item in ItemList)
                result.Add(visitfunction(item));
        }
        return result;
    }
