    class _Program
    {
        public static int MyInput { get; set; }
        static void Main(string[] args)
        {
            int input = 11;
            for (int i = 0; i < 1000 ; i++)
            {
                MyInput = input + 1;
                FuncA(delegate(IAsyncResult result)
                {
                    AsyncResult<Int32> funcBResult = result as AsyncResult<Int32>;
                    Int32 value = funcBResult.EndInvoke() + 3;
                    Console.WriteLine("Final value: " + value);
                }, null); ; // using callback method
            }
            Console.ReadLine();
        }
        public static IAsyncResult FuncA(AsyncCallback callback, Object state)
        {
            AsyncResult<Int32> result = new AsyncResult<int>(callback, state);
            ThreadPool.QueueUserWorkItem(FuncB, result);
            return result;
        }
        public static void FuncB(Object asyncResult)
        {
            AsyncResult<Int32> result = asyncResult as AsyncResult<Int32>;
            try
            {
                Int32 value = MyInput + 2;
                result.SetAsCompleted(false, value);
            }
            catch (Exception ex)
            {
                result.SetAsCompleted(false, ex);
            }
        }
    }
