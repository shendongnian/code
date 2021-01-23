    public static TCollection EmptyIfDefault<TCollection, T>(this TCollection collection)
            where TCollection: class, IEnumerable<T>, new()
        {
            return collection ?? new TCollection();
        }
