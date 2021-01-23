    class Program
    {
        static readonly ReusableAwaiter<int> _awaiter = new ReusableAwaiter<int>();
        static void Main(string[] args)
        {
            Task.Run(() => Test());
            Console.ReadLine();
            _awaiter.TrySetResult(22);
            Console.ReadLine();
            _awaiter.TrySetException(new Exception("ERR"));
            Console.ReadLine();
        }
        static async void Test()
        {
            int a = await AsyncMethod();
            Console.WriteLine(a);
            try
            {
                await AsyncMethod();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        static  ReusableAwaiter<int> AsyncMethod()
        {
            return _awaiter.Reset();
        }
    }
