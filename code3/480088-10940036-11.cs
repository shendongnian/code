    public interface IFakeEnumA
    {
        string GetKey();
    }
    public struct ClientXFakeEnumA : IFakeEnumA
    {
        private readonly string _key;
        private ClientXFakeEnum(string key)
        {
            _key = key;
        }
        // Don't forget default for structs is 0,
        // therefore all structs should have a "0" property.
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
        string IFakeEnumA.GetKey()
        {
            return _key;
        }
        public override bool Equals(object obj)
        {
            return (obj is IFakeEnumA) && ((IFakeEnumA)obj).GetKey() == _key;
        }
        public override int GetHashCode()
        {
            return _key.GetHashCode();
        }
        public static bool operator==(ClientXFakeEnumA x, IFakeEnumA y)
        {
            return x.Equals(y);
        }
        public static bool operator==(IFakeEnumA x, ClientXFakeEnumA y)
        {
            return y.Equals(x);
        }
        public static bool operator!=(ClientXFakeEnumA x, IFakeEnumA y)
        {
            return !x.Equals(y);
        }
        public static bool operator!=(IFakeEnumA x, ClientXFakeEnumA y)
        {
            return !y.Equals(x);
        }
        // Override Equals(), GetHashCode() and operators ==, !=
        // So clients can compare structures to each other (to interface)
    }
