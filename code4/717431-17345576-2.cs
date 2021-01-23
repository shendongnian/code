    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("The Ping Elapsed event was raised at {0}", e.SignalTime);
        //Record through win32dll the application foreground caption
        // You miss the output or usage of the method there.
        GetActiveFileNameTitle();
        // Try 
        var procName = GetActiveFileNameTitle();
        Console.WriteLine(procName);
        //Store into collection object, Push into ArrayList, Push into process id
    }
