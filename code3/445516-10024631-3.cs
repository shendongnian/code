    class Program
    {
        static void Main()
        {
            Console.WriteLine(DoServiceCall(times2, 5));
            Console.ReadKey();
        }
        public static TResult DoServiceCall<T, TResult>(Func<T, TResult> operation,
                                                        T request)
        {
            return operation(request);
        }
        private static int times2(int x)
        {
            return 2 * x;
        }
    }
    
