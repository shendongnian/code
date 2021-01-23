    /// <summary>
    /// Returns true if source has at least <paramref name="count"/> elements efficiently.
    /// </summary>
    /// <remarks>Based on int Enumerable.Count() method.</remarks>
    public static bool HasCountOfAtLeast<TSource>(this IEnumerable<TSource> source, int count)
    {
        source.ThrowIfArgumentNull("source");
        var collection = source as ICollection<TSource>;
        if (collection != null)
        {
            return collection.Count >= count;
        }
        var collection2 = source as ICollection;
        if (collection2 != null)
        {
            return collection2.Count >= count;
        }
        int num = 0;
        checked
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    num++;
                    if (num >= count)
                    {
                        return true;
                    }
                }
            }
        }
        // returns true for source with 0 elements and count 0
        return num == count;
    }
