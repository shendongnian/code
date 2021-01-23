    public interface IFakeEnumA
    {
        int GetValue();
    }
    public struct ClientXFakeEnumA : IFakeEnumA
    {
        private readonly int _value; // Only master struct should have a public getter for this
        private ClientXFakeEnum(int value)
        {
            _value = value;
        }
        // Don't forget default for structs is 0, therefore all structs should have a "0" property.
        public ClientXFakeEnumA Default
        {
            get
            {
                return new ClientXFakeEnumA();
            }
        }
        public ClientXFakeEnumA OptionB
        {
            get
            {
                return new ClientXFakeEnumA(10);
            }
        }
        IFakeEnumA.GetValue()
        {
            return _value;
        }
        // Override Equals(), GetHashCode() and operators ==, != (and optionally <, <=, >, >=)
        // So clients can compare structures to each other (to interface)
    }
