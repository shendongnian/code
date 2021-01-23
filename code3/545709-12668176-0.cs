    namespace System.Collections.Generic { 
    using System;
    using System.Collections;
    using System.Diagnostics; 
    using System.Diagnostics.Contracts;
    using System.Runtime.Serialization; 
    using System.Security.Permissions; 
    [DebuggerTypeProxy(typeof(Mscorlib_DictionaryDebugView<,>))] 
    [DebuggerDisplay("Count = {Count}")]
    [Serializable]
    [System.Runtime.InteropServices.ComVisible(false)]
    public class Dictionary<TKey,TValue>: IDictionary<TKey,TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue>, ISerializable, IDeserializationCallback  { 
        private struct Entry { 
            public int hashCode;    // Lower 31 bits of hash code, -1 if unused 
            public int next;        // Index of next entry, -1 if last
            public TKey key;           // Key of entry 
            public TValue value;         // Value of entry
        }
        private int[] buckets; 
        private Entry[] entries;
        private int count; 
        private int version; 
        private int freeList;
        private int freeCount; 
        private IEqualityComparer<TKey> comparer;
        private KeyCollection keys;
        private ValueCollection values;
        private Object _syncRoot; 
        // constants for serialization 
        private const String VersionName = "Version"; 
        private const String HashSizeName = "HashSize";  // Must save buckets.Length
        private const String KeyValuePairsName = "KeyValuePairs"; 
        private const String ComparerName = "Comparer";
        public Dictionary(): this(0, null) {}
 
        public Dictionary(int capacity): this(capacity, null) {}
 
        public Dictionary(IEqualityComparer<TKey> comparer): this(0, comparer) {} 
        public Dictionary(int capacity, IEqualityComparer<TKey> comparer) { 
            if (capacity < 0) ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity);
            if (capacity > 0) Initialize(capacity);
            this.comparer = comparer ?? EqualityComparer<TKey>.Default;
        } 
        public Dictionary(IDictionary<TKey,TValue> dictionary): this(dictionary, null) {} 
 
        public Dictionary(IDictionary<TKey,TValue> dictionary, IEqualityComparer<TKey> comparer):
            this(dictionary != null? dictionary.Count: 0, comparer) { 
            if( dictionary == null) {
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.dictionary);
            } 
            foreach (KeyValuePair<TKey,TValue> pair in dictionary) { 
                Add(pair.Key, pair.Value); 
            }
        } 
        protected Dictionary(SerializationInfo info, StreamingContext context) {
            //We can't do anything with the keys and values until the entire graph has been deserialized
            //and we have a resonable estimate that GetHashCode is not going to fail.  For the time being, 
            //we'll just cache this.  The graph is not valid until OnDeserialization has been called.
            HashHelpers.SerializationInfoTable.Add(this, info); 
        } 
        public IEqualityComparer<TKey> Comparer { 
            get {
                return comparer;
            }
        } 
        public int Count { 
            get { return count - freeCount; } 
        }
 
        public KeyCollection Keys {
            get {
                Contract.Ensures(Contract.Result<KeyCollection>() != null);
                if (keys == null) keys = new KeyCollection(this); 
                return keys;
            } 
        } 
        ICollection<TKey> IDictionary<TKey, TValue>.Keys { 
            get {
                if (keys == null) keys = new KeyCollection(this);
                return keys;
            } 
        }
 
        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys { 
            get {
                if (keys == null) keys = new KeyCollection(this); 
                return keys;
            }
        }
 
        public ValueCollection Values {
            get { 
                Contract.Ensures(Contract.Result<ValueCollection>() != null); 
                if (values == null) values = new ValueCollection(this);
                return values; 
            }
        }
        ICollection<TValue> IDictionary<TKey, TValue>.Values { 
            get {
                if (values == null) values = new ValueCollection(this); 
                return values; 
            }
        } 
        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values {
            get {
                if (values == null) values = new ValueCollection(this); 
                return values;
            } 
        } 
        public TValue this[TKey key] { 
            get {
                int i = FindEntry(key);
                if (i >= 0) return entries[i].value;
                ThrowHelper.ThrowKeyNotFoundException(); 
                return default(TValue);
            } 
            set { 
                Insert(key, value, false);
            } 
        }
        public void Add(TKey key, TValue value) {
            Insert(key, value, true); 
        }
 
        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair) { 
            Add(keyValuePair.Key, keyValuePair.Value);
        } 
        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair) {
            int i = FindEntry(keyValuePair.Key);
            if( i >= 0 && EqualityComparer<TValue>.Default.Equals(entries[i].value, keyValuePair.Value)) { 
                return true;
            } 
            return false; 
        }
 
        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair) {
            int i = FindEntry(keyValuePair.Key);
            if( i >= 0 && EqualityComparer<TValue>.Default.Equals(entries[i].value, keyValuePair.Value)) {
                Remove(keyValuePair.Key); 
                return true;
            } 
            return false; 
        }
 
        public void Clear() {
            if (count > 0) {
                for (int i = 0; i < buckets.Length; i++) buckets[i] = -1;
                Array.Clear(entries, 0, count); 
                freeList = -1;
                count = 0; 
                freeCount = 0; 
                version++;
            } 
        }
        public bool ContainsKey(TKey key) {
            return FindEntry(key) >= 0; 
        }
 
        public bool ContainsValue(TValue value) { 
            if (value == null) {
                for (int i = 0; i < count; i++) { 
                    if (entries[i].hashCode >= 0 && entries[i].value == null) return true;
                }
            }
            else { 
                EqualityComparer<TValue> c = EqualityComparer<TValue>.Default;
                for (int i = 0; i < count; i++) { 
                    if (entries[i].hashCode >= 0 && c.Equals(entries[i].value, value)) return true; 
                }
            } 
            return false;
        }
        private void CopyTo(KeyValuePair<TKey,TValue>[] array, int index) { 
            if (array == null) {
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array); 
            } 
            if (index < 0 || index > array.Length ) { 
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            }
            if (array.Length - index < Count) { 
                ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
            } 
 
            int count = this.count;
            Entry[] entries = this.entries; 
            for (int i = 0; i < count; i++) {
                if (entries[i].hashCode >= 0) {
                    array[index++] = new KeyValuePair<TKey,TValue>(entries[i].key, entries[i].value);
                } 
            }
        } 
 
        public Enumerator GetEnumerator() {
            return new Enumerator(this, Enumerator.KeyValuePair); 
        }
        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() {
            return new Enumerator(this, Enumerator.KeyValuePair); 
        }
 
        [System.Security.SecurityCritical]  // auto-generated_required 
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
            if (info==null) { 
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.info);
            }
            info.AddValue(VersionName, version);
 
    #if FEATURE_RANDOMIZED_STRING_HASHING
            info.AddValue(ComparerName, HashHelpers.GetEqualityComparerForSerialization(comparer), typeof(IEqualityComparer<TKey>)); 
    #else 
            info.AddValue(ComparerName, comparer, typeof(IEqualityComparer<TKey>));
    #endif 
            info.AddValue(HashSizeName, buckets == null ? 0 : buckets.Length); //This is the length of the bucket array.
            if( buckets != null) {
                KeyValuePair<TKey, TValue>[] array = new KeyValuePair<TKey, TValue>[Count]; 
                CopyTo(array, 0);
                info.AddValue(KeyValuePairsName, array, typeof(KeyValuePair<TKey, TValue>[])); 
            } 
        }
 
        private int FindEntry(TKey key) {
            if( key == null) {
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
            } 
            if (buckets != null) { 
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF; 
                for (int i = buckets[hashCode % buckets.Length]; i >= 0; i = entries[i].next) {
                    if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key)) return i; 
                }
            }
            return -1;
        } 
        private void Initialize(int capacity) { 
            int size = HashHelpers.GetPrime(capacity); 
            buckets = new int[size];
            for (int i = 0; i < buckets.Length; i++) buckets[i] = -1; 
            entries = new Entry[size];
            freeList = -1;
        }
 
        private void Insert(TKey key, TValue value, bool add) {
 
            if( key == null ) { 
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
            } 
            if (buckets == null) Initialize(0);
            int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Length; 
    #if FEATURE_RANDOMIZED_STRING_HASHING 
            int collisionCount = 0; 
    #endif
 
            for (int i = buckets[targetBucket]; i >= 0; i = entries[i].next) {
                if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key)) {
                    if (add) {
                        ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_AddingDuplicate); 
                    }
                    entries[i].value = value; 
                    version++; 
                    return;
                } 
    #if FEATURE_RANDOMIZED_STRING_HASHING
                collisionCount++;
    #endif 
            }
            int index; 
            if (freeCount > 0) { 
                index = freeList;
                freeList = entries[index].next; 
                freeCount--;
            }
            else {
                if (count == entries.Length) 
                {
                    Resize(); 
                    targetBucket = hashCode % buckets.Length; 
                }
                index = count; 
                count++;
            }
            entries[index].hashCode = hashCode; 
            entries[index].next = buckets[targetBucket];
            entries[index].key = key; 
            entries[index].value = value; 
            buckets[targetBucket] = index;
            version++; 
    #if FEATURE_RANDOMIZED_STRING_HASHING
            if(collisionCount > HashHelpers.HashCollisionThreshold && HashHelpers.IsWellKnownEqualityComparer(comparer))
            { 
                comparer = (IEqualityComparer<TKey>) HashHelpers.GetRandomizedEqualityComparer(comparer);
                Resize(entries.Length, true); 
            } 
    #endif
 
        }
        public virtual void OnDeserialization(Object sender) {
            SerializationInfo siInfo; 
            HashHelpers.SerializationInfoTable.TryGetValue(this, out siInfo);
 
            if (siInfo==null) { 
                // It might be necessary to call OnDeserialization from a container if the container object also implements
                // OnDeserialization. However, remoting will call OnDeserialization again. 
                // We can return immediately if this function is called twice.
                // Note we set remove the serialization info from the table at the end of this method.
                return;
            } 
            int realVersion = siInfo.GetInt32(VersionName); 
            int hashsize = siInfo.GetInt32(HashSizeName); 
            comparer   = (IEqualityComparer<TKey>)siInfo.GetValue(ComparerName, typeof(IEqualityComparer<TKey>));
 
            if( hashsize != 0) {
                buckets = new int[hashsize];
                for (int i = 0; i < buckets.Length; i++) buckets[i] = -1;
                entries = new Entry[hashsize]; 
                freeList = -1;
 
                KeyValuePair<TKey, TValue>[] array = (KeyValuePair<TKey, TValue>[]) 
                    siInfo.GetValue(KeyValuePairsName, typeof(KeyValuePair<TKey, TValue>[]));
 
                if (array==null) {
                    ThrowHelper.ThrowSerializationException(ExceptionResource.Serialization_MissingKeys);
                }
 
                for (int i=0; i<array.Length; i++) {
                    if ( array[i].Key == null) { 
                        ThrowHelper.ThrowSerializationException(ExceptionResource.Serialization_NullKey); 
                    }
                    Insert(array[i].Key, array[i].Value, true); 
                }
            }
            else {
                buckets = null; 
            }
 
            version = realVersion; 
            HashHelpers.SerializationInfoTable.Remove(this);
        } 
        private void Resize() {
            Resize(HashHelpers.ExpandPrime(count), false);
        } 
        private void Resize(int newSize, bool forceNewHashCodes) { 
            Contract.Assert(newSize >= entries.Length); 
            int[] newBuckets = new int[newSize];
            for (int i = 0; i < newBuckets.Length; i++) newBuckets[i] = -1; 
            Entry[] newEntries = new Entry[newSize];
            Array.Copy(entries, 0, newEntries, 0, count);
            if(forceNewHashCodes) {
                for (int i = 0; i < count; i++) { 
                    if(newEntries[i].hashCode != -1) {
                        newEntries[i].hashCode = (comparer.GetHashCode(newEntries[i].key) & 0x7FFFFFFF); 
                    } 
                }
            } 
            for (int i = 0; i < count; i++) {
                int bucket = newEntries[i].hashCode % newSize;
                newEntries[i].next = newBuckets[bucket];
                newBuckets[bucket] = i; 
            }
            buckets = newBuckets; 
            entries = newEntries; 
        }
 
        public bool Remove(TKey key) {
            if(key == null) {
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
            } 
            if (buckets != null) { 
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF; 
                int bucket = hashCode % buckets.Length;
                int last = -1; 
                for (int i = buckets[bucket]; i >= 0; last = i, i = entries[i].next) {
                    if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key)) {
                        if (last < 0) {
                            buckets[bucket] = entries[i].next; 
                        }
                        else { 
                            entries[last].next = entries[i].next; 
                        }
                        entries[i].hashCode = -1; 
                        entries[i].next = freeList;
                        entries[i].key = default(TKey);
                        entries[i].value = default(TValue);
                        freeList = i; 
                        freeCount++;
                        version++; 
                        return true; 
                    }
                } 
            }
            return false;
        }
 
        public bool TryGetValue(TKey key, out TValue value) {
            int i = FindEntry(key); 
            if (i >= 0) { 
                value = entries[i].value;
                return true; 
            }
            value = default(TValue);
            return false;
        } 
        // This is a convenience method for the internal callers that were converted from using Hashtable. 
        // Many were combining key doesn't exist and key exists but null value (for non-value types) checks. 
        // This allows them to continue getting that behavior with minimal code delta. This is basically
        // TryGetValue without the out param 
        internal TValue GetValueOrDefault(TKey key) {
            int i = FindEntry(key);
            if (i >= 0) {
                return entries[i].value; 
            }
            return default(TValue); 
        } 
        bool ICollection<KeyValuePair<TKey,TValue>>.IsReadOnly { 
            get { return false; }
        }
        void ICollection<KeyValuePair<TKey,TValue>>.CopyTo(KeyValuePair<TKey,TValue>[] array, int index) { 
            CopyTo(array, index);
        } 
 
        void ICollection.CopyTo(Array array, int index) {
            if (array == null) { 
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
            }
            if (array.Rank != 1) { 
                ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
            } 
 
            if( array.GetLowerBound(0) != 0 ) {
                ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound); 
            }
            if (index < 0 || index > array.Length) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum); 
            }
 
            if (array.Length - index < Count) { 
                ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
            } 
            KeyValuePair<TKey,TValue>[] pairs = array as KeyValuePair<TKey,TValue>[];
            if (pairs != null) {
                CopyTo(pairs, index); 
            }
            else if( array is DictionaryEntry[]) { 
                DictionaryEntry[] dictEntryArray = array as DictionaryEntry[]; 
                Entry[] entries = this.entries;
                for (int i = 0; i < count; i++) { 
                    if (entries[i].hashCode >= 0) {
                        dictEntryArray[index++] = new DictionaryEntry(entries[i].key, entries[i].value);
                    }
                } 
            }
            else { 
                object[] objects = array as object[]; 
                if (objects == null) {
                    ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType); 
                }
                try {
                    int count = this.count; 
                    Entry[] entries = this.entries;
                    for (int i = 0; i < count; i++) { 
                        if (entries[i].hashCode >= 0) { 
                            objects[index++] = new KeyValuePair<TKey,TValue>(entries[i].key, entries[i].value);
                        } 
                    }
                }
                catch(ArrayTypeMismatchException) {
                    ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType); 
                }
            } 
        } 
        IEnumerator IEnumerable.GetEnumerator() { 
            return new Enumerator(this, Enumerator.KeyValuePair);
        }
        bool ICollection.IsSynchronized { 
            get { return false; }
        } 
 
        object ICollection.SyncRoot {
            get { 
                if( _syncRoot == null) {
                    System.Threading.Interlocked.CompareExchange<Object>(ref _syncRoot, new Object(), null);
                }
                return _syncRoot; 
            }
        } 
 
        bool IDictionary.IsFixedSize {
            get { return false; } 
        }
        bool IDictionary.IsReadOnly {
            get { return false; } 
        }
