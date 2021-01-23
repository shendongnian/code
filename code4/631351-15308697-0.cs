    public static class ListExtensionMethods
    {
        public static int BinarySearch<T>(this List<T> list, object value)
        {
            if (value is T)
                return list.BinarySearch((T)value);
            return -1;
        }
    }
