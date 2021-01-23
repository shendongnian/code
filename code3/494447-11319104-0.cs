    public void myFunc()
    {
        Process p = new Process();
        p.StartInfo.FileName = "myProgram.exe";
        p.StartInfo.RedirectStandardOutput = true;
        p.EnableRaisingEvents = true;
        p.Exited += new EventHandler((sender, args) => processExited(p));
        p.Start();
    }
    
    private void processExited(Process p)
    {
        Console.WriteLine(p.ExitTime);
    }
