    class FunctionWithCounter<T, TResult>
    {
        public readonly Func<T, TResult> Function;
        public int Calls { get; private set; }
        public FunctionWithCounter(Func<T, TResult> function)
        {
            Calls = 0;
            Function = x =>
                {
                    Calls++;
                    return function(x);
                };
        }        
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var callCounter = new FunctionWithCounter<double,double>(x => x * x);
            var func = callCounter.Function;
            for (int i = 0; i < 5; i++)
            {
                double d = func(i);
            }
            Console.WriteLine(callCounter.Calls);
            Console.ReadKey();
        }
    }
