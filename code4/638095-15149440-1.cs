    class Program
    {
        static void Main(string[] args)
        {
            string resFromFunctionToBeWRapped = CallMethod(() => FunctionToBeWrapped());
            int resFromAnon = CallMethod(() => {
                Console.WriteLine("in anonymous function");
                return 5;
            } );
            Console.WriteLine("value is {0}", resFromFunctionToBeWRapped);
            Console.WriteLine("value from anon is {0}", resFromAnon);
            Console.ReadLine();
        }
        private static TResult CallMethod<TResult>(Func<TResult> functionToCall) //where T : class
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
    }
