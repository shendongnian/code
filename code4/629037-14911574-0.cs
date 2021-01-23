    public interface IPair<out TKey, out TValue>
    {
        TKey Key { get; }
        TValue Value { get; }
    }
    
    public class Pair<TKey, TValue> : IPair<TKey, TValue>
    {
        public TKey Key { get; private set; }
        public TValue Value { get; private set; }
    
        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    
        public Pair(KeyValuePair<TKey, TValue> pair)
            : this(pair.Key, pair.Value) {   }
    }
    
    public static class PairSequenceExtensions
    {
        public static IEnumerable<IPair<TKey, TValue>> GetCovariantView<TKey, TValue>
                (this IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
    
            return source.Select(pair => new Pair<TKey, TValue>(pair));
        }
    
        public static IEnumerable<IPair<TKey, TValue>> CastPairs<TKey, TValue>
            (this IEnumerable<IPair<TKey, TValue>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
    
            return source;
        }
    }
