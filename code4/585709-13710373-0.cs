    public static IEnumerable<IList<T>> Partition<T>(this IEnumerable<T> items, int partitionSize)
    {
        return items
                .ToObservable() // Converting sequence to observable sequence
                .Buffer(partitionSize) // Splitting it on spececified "partitions"
                .ToEnumerable(); // Converting it back to ordinary sequence
    }
