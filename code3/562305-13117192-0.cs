    [Serializable]
    public class Bytes
    {
        private byte[] _value;
        public byte[] Value { get { return _value; } }
        public Bytes(byte[] bytesValue)
        {
            _value = bytesValue;
        }
        public override bool Equals(object obj) {...}
        public override int GetHashCode() {...}
        public override string ToString() {...}
    }
