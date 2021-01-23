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
    }
