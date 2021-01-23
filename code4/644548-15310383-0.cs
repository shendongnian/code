    public abstract class DataTag
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public abstract object WeakValue { get; }
        public abstract object WeakRawValue { get; }
    }
    public abstract class DataTag<TRaw, TVal> : DataTag
    {
        public abstract TVal Value { get; }
        public TRaw RawValue { get; set; }
        public override object WeakValue { get { return Value; } }
        public override object WeakRawValue { get { return RawValue; } }
    }
