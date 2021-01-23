    var processes = new List<Process>();
    int sent = 0;
    
    foreach (string fileName in chunkFiles)
    {
        Process p = GenerateProcessInstance();
        p.StartInfo.Arguments = string.Format("{0} {1} false {2}", fileName, Id, logName);
        p.Start();
        processes.Add(p);
    }
    
    foreach (Process p in processes)
    {
        p.WaitForExit();
        sent += p.ExitCode;
    }
