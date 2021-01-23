    public static bool IsIncreasingMonotonically<T>(
        this IEnumerable<T> _this)
        where T : IComparable<T>
    {
        using (var e = _this.GetEnumerator())
        {
            if (!e.MoveNext())
                return true;
            T prev = e.Current;
            while (e.MoveNext())
            {
                if (prev.CompareTo(e.Current) > 0)
                    return false;
                prev = e.Current;
            }
            return true;
        }
    }
