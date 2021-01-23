    public struct SafeInt
    {
        public int Value { get; private set; }
        public static implicit operator int(SafeInt safeInt)
        {
            return safeInt.Value;
        }
        public static explicit operator SafeInt(string obj)
        {
            return new SafeInt() { Value = SafeParse(obj) };
        }
        public static int SafeParse(object value)
        {
            int output;
            int.TryParse((value ?? "0").ToString(), out output);
            return output;
        }
    }
