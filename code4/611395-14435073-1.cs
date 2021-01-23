    [Serializable]
    public class DefaultableStringValue : DefaultableValue<string>
    {
        public DefaultableStringValue() : base(s => s) { }
    }
    [Serializable]
    public class DefaultableIntegerValue : DefaultableValue<int>
    {
        public DefaultableIntegerValue() : base(int.Parse) { }
    }
    [Serializable]
    public class DefaultableBooleanValue : DefaultableValue<bool>
    {
        public DefaultableBooleanValue() : base(bool.Parse) { }
    }
