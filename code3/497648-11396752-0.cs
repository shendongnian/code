    public class Foo<T>
    {
        public static string MyMethod()
        {
            return "Method: " + typeof(T).ToString();
        }
    }
    
    class Program
    {
        static void Main()
        {
            Type myType = typeof(string);
            var fooType = typeof(Foo<>).MakeGenericType(myType);
            var myMethod = fooType.GetMethod("MyMethod", BindingFlags.Static | BindingFlags.Public);
            var result = (string)myMethod.Invoke(null, null);
            Console.WriteLine(result);
        }
    }
