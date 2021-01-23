    Progress<string> progress = new Progress<string>();
    progress.ProgressChanged += (s, data) => Console.WriteLine(data);
    for (int i = 0; i < 2; i++)
        Task.Run(() => DoWork(progress));
---
    public static void DoWork(IProgress<string> progress)
    {
        int i = 0;
        while (true)
        {
            Thread.Sleep(500);//placeholder for real work
            progress.Report(i++.ToString());
        }
    }
