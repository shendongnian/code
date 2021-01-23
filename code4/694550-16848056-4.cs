    public class Sequences {
        public static IEnumerable<int> GetIntegerRange(int start, int count) {
            return Enumerable.Range(start, count);
        }
        public static IInfiniteEnumerable<int> GetFibonacciSequence() {
            return new InfiniteEnumerableWrapper<int>(GetFibonacciSequenceInternal());
        }
        static IEnumerable<int> GetFibonacciSequenceInternal() {
            var p = 0;
            var q = 1;
            while (true) {
                yield return p;
                var newQ = p + q;
                p = q;
                q = newQ;
            }
        }
    }
