    public struct Num<T>
    {
        private readonly T _Value;
        public Num(T value)
        {
            _Value = value;
        }
        static public explicit operator Num<T>(T value)
        {
            return new Num<T>(value);
        }
    }
    class Program
    {
        static void Main()
        {
            double d = 2.5;
            Num<byte> b = (Num<byte>)d;
        }
    }
