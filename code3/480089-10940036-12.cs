    public struct MasterFakeEnumA : IFakeEnumA
    {
        private readonly string _key;
        private MasterFakeEnumA(string key)
        {
            _key = key;
        }
        // Don't forget default for structs is 0,
        // therefore all structs should have a "0" property.
        public MasterFakeEnumA Default
        {
            get
            {
                return new MasterFakeEnumA();
            }
        }
        // You should have all the options here
        public MasterFakeEnumA OptionB
        {
            get
            {
                return new MasterFakeEnumA(10);
            }
        }
        // Here use implicit interface implementation instead of explicit implementation
        public string GetKey()
        {
            return _key;
        }
        public static implicit operator MasterFakeEnumA(IFakeEnumA value)
        {
            return new MasterFakeEnumA(value.GetKey());
        }
        public static implicit operator string(MasterFakeEnumA value)
        {
            return new value._key;
        }
        // Don't forget to implement Equals, GetHashCode,
        // == and != like in the client structures
    }
