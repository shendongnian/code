    public interface IStatus
    {
        string GetKey();
    }
    public struct ClientXStatus : IStatus
    {
        private readonly string _key;
        private ClientXStatus(string key)
        {
            _key = key;
        }
        // Don't forget default for structs is 0,
        // therefore all structs should have a "0" property.
        public ClientXStatus Default
        {
            get
            {
                return new ClientXStatus();
            }
        }
        public ClientXStatus OptionB
        {
            get
            {
                return new ClientXStatus(10);
            }
        }
        string IStatus.GetKey()
        {
            return _key;
        }
        public override bool Equals(object obj)
        {
            return (obj is IStatus) && ((IStatus)obj).GetKey() == _key;
        }
        public override int GetHashCode()
        {
            return _key.GetHashCode();
        }
        public static bool operator==(ClientXStatus x, IStatus y)
        {
            return x.Equals(y);
        }
        public static bool operator==(IStatus x, ClientXStatus y)
        {
            return y.Equals(x);
        }
        public static bool operator!=(ClientXStatus x, IStatus y)
        {
            return !x.Equals(y);
        }
        public static bool operator!=(IStatus x, ClientXStatus y)
        {
            return !y.Equals(x);
        }
        // Override Equals(), GetHashCode() and operators ==, !=
        // So clients can compare structures to each other (to interface)
    }
