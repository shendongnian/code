    myProcess.EnableRaisingEvents = true;
    myProcess.Exited += new EventHandler(myProcess_Exited);
...
    private void myProcess_Exited(object sender, System.EventArgs e)
    {
        Console.WriteLine("Exit time:    {0}\r\n" +
            "Exit code:    {1}\r\nElapsed time: {2}", myProcess.ExitTime, myProcess.ExitCode, elapsedTime);
    }
