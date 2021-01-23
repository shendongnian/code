    static void Main(string[] args)
    {
        Task.Run(async () => { await Task.WhenAll(jobslist.Select(nl => RunMulti(nl))); }).GetAwaiter().GetResult();
    }
    private static async Task RunMulti(List<string> joblist)
    {
        await ...
    }
