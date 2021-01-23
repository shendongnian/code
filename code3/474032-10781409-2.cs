    private Process[] myProcess = Process.GetProcessesByName("notepad");
    public Process SomeProcess
    {
        get
        {
            return myProcess[0];
        }
    }
