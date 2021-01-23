    public class Node<TKey, TValue> where TKey : IEquatable<TKey>
    {
        public TKey Key { get; set; }
        public TKey ParentKey { get; set; }
        public TValue Data { get; set; }
        public readonly List<Node<TKey, TValue>> Children = new List<Node<TKey, TValue>>();
    }
