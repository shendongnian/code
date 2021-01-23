    public static int ExceptWith<TItem>(this ICollection<TItem> collection, IEnumerable<TItem> other)
    {
        if (ReferenceEquals(collection, null))
        {
            throw new ArgumentNullException("collection");
        }
        else if (ReferenceEquals(other, null))
        {
            throw new ArgumentNullException("other");
        }
        else
        {
            int count = 0;
            foreach (var item in other)
            {
                if (collection.Remove(item))
                {
                    count++;
                }
            }
            return count;
        }
    }
