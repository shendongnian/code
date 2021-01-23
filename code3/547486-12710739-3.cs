    public int BinarySearch<T>(this ICollection<T> elements, T item) where T : IComparable
    {
        // Assumes that elements is already sorted!
        var s = 0;
        var e = elements.Count - 1;
        while (s <= e)
        {
            var m = (s + e + 1) / 2;
            var cmp = elements[m].CompareTo(item);
            switch (cmp)
            {
                case -1:
                    s = m + 1;
                    break;
                case 1:
                    e = m - 1;
                    break;
                default:
                    return m;
            }
        }
        return -1;
    }
