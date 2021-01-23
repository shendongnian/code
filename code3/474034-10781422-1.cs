    public Process SomeProcess
    {
       get
       {
            Process[] myProcess = Process.GetProcessesByName("notepad"); 
            return myProcess[0];
       }
    }
