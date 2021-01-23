    class Program
    {
        public static void Perform<T>(T value)
        {
            Console.WriteLine("Called = " + value);
        }
        public static Delegate CreateAction(Type type)
        {
            var methodInfo = typeof (Program).GetMethod("Perform").MakeGenericMethod(type);
            var actionT = typeof (Action<>).MakeGenericType(type);
            return Delegate.CreateDelegate(actionT, methodInfo);
        }
        static void Main(string[] args)
        {
            CreateAction(typeof (int)).DynamicInvoke(5);
            Console.ReadLine();
        }
    }
