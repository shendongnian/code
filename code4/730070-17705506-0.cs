    public struct SafeInt
    {
        private SafeInt() { }
        public int Value { get; private set; }
        public static implicit operator int(SafeInt safeInt)
        {
            return safeInt.Value;
        }
        public static explicit operator SafeInt(string obj)
        {
            return new SafeInt() { Value = SafeParse(obj) };
        }
        public static int SafeParse(string value)
        {
            int output;
            int.TryParse(value, out output);
            return output;
        }
    }
