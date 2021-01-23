    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetNulllableUnderlyingType(new TestClass().value));
            Console.WriteLine(GetNulllableUnderlyingType(new TestClass()));
            Console.ReadKey();
        }
        public class TestClass
        {
            public int? value;
        }
        public static Type GetNulllableUnderlyingType<T>(T value)
        {
            Type result =  Nullable.GetUnderlyingType(typeof (T));
            return result;
        }
    }
