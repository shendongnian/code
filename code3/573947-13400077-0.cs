    static void Main()
    {
        Thread t = new Thread(new ThreadStart(RunExe))
        t.Start
        Thread t2 = new Thread(new ThreadStart(RunExe))
        t2.Start
    }
    
    public void RunExe()
    {
        foreach(string fileName in chunkFiles)
        {
            p = GenerateProcessInstance();
            p.StartInfo.Arguments = string.Format("{0} {1} false {2}", fileName, Id, logName);
            p.Start();
            p.WaitForExit();
            sent += p.ExitCode;
        }
    }
