    public static class Application
    {
        public static void Main()
        {
            Console.WriteLine(Marshal.SizeOf(typeof(Int32)) * 8);
            Console.WriteLine(5.IsSigned());
            Console.WriteLine(((UInt32)5).IsSigned());
            
            Console.ReadLine();
        }
    }
    public static class NumberHelper
    {
        public static Boolean IsSigned<T>(this T value) where T : struct
        {
            return !(
                typeof(T).Equals(typeof(UIntPtr)) ||
                typeof(T).Equals(typeof(Byte)) ||
                typeof(T).Equals(typeof(UInt16)) ||
                typeof(T).Equals(typeof(UInt32)) ||
                typeof(T).Equals(typeof(UInt64)));
        }
    }
