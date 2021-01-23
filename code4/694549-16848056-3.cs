    //TryGetCount() returns null if the sequence is infinite
    public static class EnumerableExtensions {
        public static int? TryGetCount<T>(this IEnumerable<T> sequence) {
            if (sequence is IInfiniteEnumerable<T>) {
                return null;
            } else {
                return sequence.Count();
            }
        }
    }
