    public struct CheckedNumber : IEquatable<CheckedNumber>
    {
        public CheckedNumber(int? number)
        {
            _value = number;
        }
        private int? _value;
        public int? Value { get { return _value; } }
        public bool Equals(CheckedNumber other)
        {
            return _value == other._value;
        }
    }
