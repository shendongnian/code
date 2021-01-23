    public static class ListExtensions
    {
        public static int RemoveAll<T>(this List<T> list, Predicate<T> predicate, Action<T> action)
        {
            return list.RemoveAll(item =>
            {
                if (predicate(item))
                {
                    action(item);
                    return true;
                }
                return false;
            });
        }
    }
