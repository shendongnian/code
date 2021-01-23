    BigInt b = "1234";
    public class BigInt
    {
        public static implicit operator BigInt(string value)
        {
            return new BigInt {Value = value};
        }
        public string Value { get; private set; }
    }
