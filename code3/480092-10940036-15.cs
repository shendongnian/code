    public struct MasterStatus : IStatus
    {
        private readonly string _key;
        private MasterStatus(string key)
        {
            _key = key;
        }
        // Don't forget default for structs is 0,
        // therefore all structs should have a "0" property.
        public MasterStatus Default
        {
            get
            {
                return new MasterStatus();
            }
        }
        // You should have all the options here
        public MasterStatus OptionB
        {
            get
            {
                return new MasterStatus(10);
            }
        }
        // Here use implicit interface implementation instead of explicit implementation
        public string GetKey()
        {
            return _key;
        }
        public static implicit operator MasterStatus(IStatus value)
        {
            return new MasterStatus(value.GetKey());
        }
        public static implicit operator string(MasterStatus value)
        {
            return new value._key;
        }
        // Don't forget to implement Equals, GetHashCode,
        // == and != like in the client structures
    }
