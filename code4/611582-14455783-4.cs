    [Test]
    public void ExecuteHackedViaSurrogate()
    {
        // I'm using separate models **only** to keep them clean between tests;
        // normally you would use RuntimeTypeModel.Default
        var model = TypeModel.Create();
        // or just remove AsReference on Items
        model[typeof(B)][2].AsReference = false;
        // this is the evil bit: configure a surrogate for KeyValuePair<int,A>
        model[typeof(KeyValuePair<int, A>)].SetSurrogate(typeof(RefPair<int, A>));
        Execute(model);
    }
    [ProtoContract]
    public struct RefPair<TKey,TValue> {
        [ProtoMember(1)]
        public TKey Key {get; private set;}
        [ProtoMember(2, AsReference = true)]
        public TValue Value {get; private set;}
        public RefPair(TKey key, TValue value) : this() {
            Key = key;
            Value = value;
        }
        public static implicit operator KeyValuePair<TKey,TValue>
            (RefPair<TKey,TValue> val)
        {
            return new KeyValuePair<TKey,TValue>(val.Key, val.Value);
        }
        public static implicit operator RefPair<TKey,TValue>
            (KeyValuePair<TKey,TValue> val)
        {
            return new RefPair<TKey,TValue>(val.Key, val.Value);
        }
    }
