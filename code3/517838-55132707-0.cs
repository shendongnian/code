    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using JetBrains.Annotations;
    
    namespace Z
    {
        public abstract class ReadOnlyKeyedCollection<TKey, TValue> : IReadOnlyCollection<TValue>
        {
            private readonly IReadOnlyCollection<TValue> _collection;
    
            protected ReadOnlyKeyedCollection([NotNull] IReadOnlyCollection<TValue> collection)
            {
                _collection = collection ?? throw new ArgumentNullException(nameof(collection));
            }
    
            public TValue this[[NotNull] TKey key]
            {
                get
                {
                    if (key == null)
                        throw new ArgumentNullException(nameof(key));
    
                    foreach (var item in _collection)
                    {
                        var itemKey = GetKeyForItem(item);
    
                        if (Equals(key, itemKey))
                            return item;
                    }
    
                    throw new KeyNotFoundException();
                }
            }
    
            #region IReadOnlyCollection<TValue> Members
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    
            public IEnumerator<TValue> GetEnumerator()
            {
                return _collection.GetEnumerator();
            }
    
            public int Count => _collection.Count;
    
            #endregion
    
            public bool Contains([NotNull] TKey key)
            {
                if (key == null)
                    throw new ArgumentNullException(nameof(key));
    
                return _collection.Select(GetKeyForItem).Contains(key);
            }
    
            protected abstract TKey GetKeyForItem(TValue item);
        }
    }
