    [Test]
    public void ExecuteHackedViaSurrogate()
    {
        var model = TypeModel.Create();
        model[typeof(B)][2].AsReference = false; // or just remove AsReference on Items
        // this is the evil bit:
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
        public static implicit operator KeyValuePair<TKey,TValue> (RefPair<TKey,TValue> val) {
            return new KeyValuePair<TKey,TValue>(val.Key, val.Value);
        }
        public static implicit operator RefPair<TKey,TValue> (KeyValuePair<TKey,TValue> val) {
            return new RefPair<TKey,TValue>(val.Key, val.Value);
        }
    }
