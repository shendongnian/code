    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper bs = new Bootstrapper();
            var getListTask = bs.GetList(); // returns the Task<List<TvChannel>>
            Task.WaitAll(getListTask); // block while the task completes
            var list = getListTask.Result;
        }
    }
