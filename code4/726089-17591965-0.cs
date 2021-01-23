    public static PerishableCollection<T> Flattened<T>(this PerishableCollection<PerishableCollection<T>> collectionOfCollections, Lifetime lifetimeOfResult) {
        if (collectionOfCollections == null) throw new ArgumentNullException("collectionOfCollections");
        var flattenedCollection = new PerishableCollection<T>();
        collectionOfCollections.CurrentAndFutureItems().Subscribe(
            c => c.Value.CurrentAndFutureItems().Subscribe(
                // OnItem: include in result, but prevent lifetimes from exceeding source's lifetime
                e => flattenedCollection.Add(
                    item: e.Value,
                    lifetime: e.Lifetime.Min(c.Lifetime)),
                // subscription to c ends when the c's lifetime ends or result is no longer needed
                c.Lifetime.Min(lifetimeOfResult)),
            // subscription ends when result is no longer needed
            lifetimeOfResult);
        return flattenedCollection;
    }
