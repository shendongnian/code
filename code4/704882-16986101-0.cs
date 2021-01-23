    static void Main(string[] args)
    {
        List<string> testTerms = new List<string>();
        testTerms.Add("test1");
        testTerms.Add("test2");
        List<Task> lstTask = new List<Task>();
        foreach (string tTerm in testTerms)
        {
            Task<List<string>> task1 =
            Task<List<string>>.Factory.StartNew(() => SearchString());
            lstTask.Add(task1);
        }
        Task[] searchTasks = (Task[])lstTask.ToArray();
        Console.WriteLine(DateTime.Now.ToString() + ": Waiting");
        Task.WaitAll(searchTasks.ToArray(), 1000);
        Console.WriteLine(DateTime.Now.ToString() + ": Done Waiting");
        Console.ReadKey();
    }
    public static List<string> SearchString()
    {
        Thread.Sleep(20000);
        return new List<string>();
    }
