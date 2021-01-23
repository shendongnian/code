    namespace System.Collections.Generic
    {
      [Serializable]
      public struct KeyValuePair<TKey, TValue>
      {
        public KeyValuePair(TKey key, TValue value);
        public TKey Key { get; }
        public TValue Value { get; }
        public override string ToString();
      }
    }
