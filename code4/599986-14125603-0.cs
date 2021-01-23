    Process p = Process.GetProcessByName("MyProcess);
    
    while(true)
    {
      p.Refresh();
      Console.WriteLine(p.ProcessThreads[0].ThreadState);
      Thread.Sleep(1000);
    }
