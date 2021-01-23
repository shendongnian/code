    class ReadOnlyKeyedCollection<TKey, TValue> : ReadOnlyCollection<TValue> {
      KeyedCollection<TKey, TValue> innerCollection;
 
      public ReadOnlyKeyedCollection(KeyedCollection<TKey, TValue> innerCollection) : base(innerCollection) {
        Fx.Assert(innerCollection != null, "innerCollection should not be null");
        this.innerCollection = innerCollection;
      }
 
      public TValue this[TKey key] {
        get {
          return this.innerCollection[key];
        }
      }
    }
