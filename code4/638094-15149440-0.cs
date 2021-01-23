    class Program
    {
        static void Main(string[] args)
        {
            string resFromFunctionToBeWRapped = CallMethod(() => FunctionToBeWrapped());
            Console.WriteLine("value is {0}", resFromFunctionToBeWRapped);
            Console.ReadLine();
        }
        private static TResult CallMethod<TResult>(Func<TResult> functionToCall) 
          {
            Console.WriteLine ("in wrapper");
            var ret = functionToCall();
            Console.WriteLine("leaving wrapper");
            return ret;
          }
        private static string FunctionToBeWrapped()
        {
            Console.WriteLine("in func");
            return "done";
        }
