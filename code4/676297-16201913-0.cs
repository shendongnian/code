    class logger {
    public void LogOpen()
    {
        StreamWriter sw = new StreamWriter("SpireCli.log");
    }
    
    public void Print(string log)
    {
        DateTime ts = DateTime.UtcNow;
        sw.WriteLine(ts + " " + log);
    }
    
    public void ExitAndOut(string log)
    {
        string Program_Exit = "Program Exit";
    
        Console.WriteLine(log);
        Console.WriteLine(Program_Exit);
        LogOpen();
        Print(log);
        Print("Exit");
        LogClose();
        Environment.Exit(1);
    }
    
    public void LogClose()
    {
        sw.Close();
    }
    }
