        public static bool IsIn<T>(this T toFind, IEnumerable<T> collection)
        {
            return collection.Contains(toFind);
        }
        public static bool IsIn<T>(this T toFind, ICollection<T> collection)
        {
            return collection.Contains(toFind);
        }
        public static bool IsIn<T>(this T toFind, params T[] items)
        {
            return toFind.IsIn(items.AsEnumerable());
        }
