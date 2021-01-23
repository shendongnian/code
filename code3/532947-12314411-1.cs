    class Program
    {
        static void Main(string[] args)
        {
            SynchronizationContext.SetSynchronizationContext(new AsyncSynchronizationContext());
            ExecuteAsyncMethod();
            Console.ReadKey();
        }
        private static async void ExecuteAsyncMethod()
        {
            await AsyncMethod();
        }
        private static async Task AsyncMethod()
        {
            throw new Exception("Exception from async");
        }
    }
