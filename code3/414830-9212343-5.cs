    using Nito.AsyncEx;
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }
        static async void MainAsync(string[] args)
        {
            Bootstrapper bs = new Bootstrapper();
            var list = await bs.GetList();
        }
    }
