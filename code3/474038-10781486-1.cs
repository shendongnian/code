    public Process SomeProcess
    {
       get
       {
            return Process.GetProcessesByName("notepad").FirstOrDefault();
       }
    }
    public string PName
    {
         return SomeProcess==null? string.Empty:SomeProcess.Name;
    }
    
    public string PID
    {
         return SomeProcess==null? string.Empty:SomeProcess.ProcessId;
    }
