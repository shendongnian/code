    class Program
    {
        public static void Generic<T>(T toDisplay)
        {
            Console.WriteLine("\r\nHere it is: {0}", toDisplay);
        }
        static void Main(string[] args)
        {
            MethodInfo mi = typeof(Program).GetMethod("Generic");
            MethodInfo miConstructed = mi.MakeGenericMethod(typeof(DateTime));
            DateTime now = DateTime.Now;
            miConstructed.Invoke(null, new object[] { now });
        }
    }
