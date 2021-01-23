    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }
        static async void MainAsync(string[] args)
        {
            Bootstrapper bs = new Bootstrapper();
            var list = await bs.GetList();
        }
    }
