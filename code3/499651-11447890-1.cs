    public static class ListExtensions
    {
        public static T SingleOrNothing<T>(this IList<T> list) where T : class
        {
            if (list.Count == 1)
                return list.Single();
            else
                return null;
        }
    }
