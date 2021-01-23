    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper bs = new Bootstrapper();
            List<TvChannel> list = Task.Run((Func<Task<List<TvChannel>>>)bs.GetList).Result;
        }
    }
