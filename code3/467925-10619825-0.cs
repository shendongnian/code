    public void FillTable()
    {
        while (true)
        {
             Thread.Sleep(interval);
             lock (lockObj)
             {
                arr.Clear();
                arr.AddRange(Process.GetProcesses());
                TableFormatter.Line();
                TableFormatter.Row("Name", "ID", "threads quantity", "Start time");
                TableFormatter.Line();
                Monitor.Pulse(lockObj);
              }
          }
    }
    public void GetGeneralInfo()
    {
        while (true)
        {
            lock (lockObj)
            {
               Monitor.Wait(lockObj);
               Console.WriteLine(arr.Count.ToString());
            }
        }
    }
