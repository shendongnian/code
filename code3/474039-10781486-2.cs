    public Process SomeProcess
    {
       get
       {
            return Process.GetProcessesByName("notepad").FirstOrDefault();
       }
    }
