    //Interface that marks infinite sequences
    public interface IInfiniteEnumerable<T> : IEnumerable<T> { }
    //Wrapper to convert an existing IEnumerable<T> to IInfiniteEnumerable<T>
    public class InfiniteEnumerableWrapper<T> : IInfiniteEnumerable<T> {
        IEnumerable<T> _enumerable;
        public InfiniteEnumerableWrapper(IEnumerable<T> enumerable) {
            _enumerable = enumerable;
        }
        public IEnumerator<T> GetEnumerator() {
            return _enumerable.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return _enumerable.GetEnumerator();
        }
    }
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
    //Two examples of sequences - a finite range sequence and the infinite Fibonacci sequence.
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
    public class TestApp {
        generates random sequences and tries to ccalculate their lengths.
        public static void Main() {
            for (int i = 0; i < 20; i++) {
                IEnumerable<int> sequence = GetRandomSequence();
                Console.WriteLine(sequence.TryGetCount() ?? double.PositiveInfinity);
            }
            Console.ReadLine();
        }
        static Random _rng = new Random();
        //Randomly generates an finite or infinite sequence
        public static IEnumerable<int> GetRandomSequence() {
            int random = _rng.Next(5) * 10;
            if (random == 0) {
                return Sequences.GetFibonacciSequence();
            } else {
                return Sequences.GetIntegerRange(0, random);
            }
        }
    }
