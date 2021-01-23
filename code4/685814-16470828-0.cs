    class Program
    {
        public static Delegate CreateFunc()
        {
          return new Func<int, int>(x => x + 1);
        }
    
        public static void Main(string[] args)
        {
            var func = CreateFunc();
            object inArg = 42;
            object result = func.DynamicInvoke(inArg);
            Console.WriteLine(result);
        }
    }
