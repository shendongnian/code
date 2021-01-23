    interface IIO
    {
        void DoOperation();
    }
    interface IIOAsync : IIO
    {
        Task DoOperationAsync();
    }
    class ClsAsync : IIOAsync
    {
        public void DoOperation()
        {
            try
            {
                DoOperationAsync().Wait();
            }
            catch (AggregateException ax)
            {
                if (ax.InnerException != null)
                    throw ax.InnerException;
                else
                    throw;
            }
        }
        public async Task DoOperationAsync()
        {
            //just an async code demo
            await Task.Delay(1000);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IIOAsync asAsync = new ClsAsync();
            IIO asSync = asAsync;
            Console.WriteLine(DateTime.Now.Second);
            asAsync.DoOperation();
            Console.WriteLine("After call to sync func using Async iface: {0}", DateTime.Now.Second);
            asAsync.DoOperationAsync().Wait();
            Console.WriteLine("After call to async func using Async iface: {0}", DateTime.Now.Second);
            asSync.DoOperation();
            Console.WriteLine("After call to sync func using Sync iface: {0}", DateTime.Now.Second);
            Console.ReadKey(true);
        }
    }
