    class Program
    {
        static async Task Main(string[] args)
        {
            Bootstrapper bs = new Bootstrapper();
            var list = await bs.GetList();
        }
    }
