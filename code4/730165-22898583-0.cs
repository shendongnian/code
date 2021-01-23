    public static class Extensions
    {
        public static IEnumerable<T> SingleEnumeration<T>(this IEnumerable<T> source)
        {
            return new SingleEnumerator<T>(source);
        }
    }
    public class SingleEnumerator<T> : IEnumerable<T>
    {
        public SingleEnumerator(IEnumerable<T> source)
        {
            this.source = source;
        }
        public IEnumerator<T> GetEnumerator()
        {
            // return an empty stream if called twice (or throw)
            if (source == null)
                return (new T[0]).AsEnumerable().GetEnumerator();
            // return the actual stream
            var result =source.GetEnumerator();
            source = null;
            return result;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // return an empty stream if called twice (or throw)
            if (source == null)
                return (new T[0]).AsEnumerable().GetEnumerator();
            var result = source.GetEnumerator();
            source = null;
            return result;
        }
        private IEnumerable<T> source;
    }
