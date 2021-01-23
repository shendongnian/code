    public static class Logger
    {
        public static void Invoke(Delegate del, params object[] args)
        {
            Console.WriteLine("Entering");
            del.DynamicInvoke(args);
            Console.WriteLine("Exiting");
        }
        public static T Invoke<T>(Delegate del, params object[] args)
        {
            Console.WriteLine("Entering");
            T rv = (T)del.DynamicInvoke(args);
            Console.WriteLine("Exiting");
            return rv;
        }
    }
