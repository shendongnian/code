    public class Program
    {
        public static T TryGetArrayValue<T>(object[] array_, int index_)
        {
            dynamic boxed = array_[index_];
            return (T)boxed;
        }
        private static void Main()
        {
            int p = 3;
            object a = p;
            var objects = new[] { a, 4.5 };
            // This works now, since the object is pointing to a class instance
            object v = TryGetArrayValue<object>(objects, 0);
            Console.WriteLine(v);
            // These both also work fine...
            double d = TryGetArrayValue<double>(objects, 1);
            Console.WriteLine(d);
            // Even the "automatic" int conversion works now
            int i = TryGetArrayValue<int>(objects, 1);
            Console.WriteLine(i);
            Console.ReadKey();
        }
    }
