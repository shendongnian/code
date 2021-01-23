    public static class Application
    {
        public enum SignedEnum : int
        {
            Foo,
            Boo,
            Zoo
        }
        public enum UnSignedEnum : uint
        {
            Foo,
            Boo,
            Zoo
        }
        public static void Main()
        {
            Console.WriteLine(Marshal.SizeOf(typeof(Int32)) * 8);
            Console.WriteLine(5.IsSigned());
            Console.WriteLine(((UInt32)5).IsSigned());
            Console.WriteLine((SignedEnum.Zoo).IsSigned());
            Console.WriteLine((UnSignedEnum.Zoo).IsSigned());
            
            Console.ReadLine();
        }
    }
    public static class NumberHelper
    {
        public static Boolean IsSigned<T>(this T value) where T : struct
        {
            return value.GetType().IsSigned();
        }
        public static Boolean IsSigned(this Type t)
        {
            return !(
                t.Equals(typeof(Byte)) ||
                t.Equals(typeof(UIntPtr)) ||
                t.Equals(typeof(UInt16)) ||
                t.Equals(typeof(UInt32)) ||
                t.Equals(typeof(UInt64)) ||
                (t.IsEnum && !Enum.GetUnderlyingType(t).IsSigned())
                );
        }
    }
