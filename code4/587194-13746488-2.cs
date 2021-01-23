    public static class EnumerableHelper {
        // usage: EnumerableHelper.AsEnumerable(obj1, obj2);
        public static IEnumerable<T> AsEnumerable<T>(params T[] items) {
            return items; 
        }
    }
