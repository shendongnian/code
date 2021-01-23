    public static class ListExtensions
    {
        public static T SingleOrNothing<T>(this IList<T> list)
        {
            if (list.Count == 1)
                return list.Single();
            else
                return null;
        }
    }
