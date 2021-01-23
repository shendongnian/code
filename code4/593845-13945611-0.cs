    public static class SkipTakeExtentions{
        public static T[] SkipTake<T>(this IEnumerable<T> items, int skipCount, int takeCount) {
            return items.Skip(skipCount).Take(takeCount).ToArray();
        }
    }
