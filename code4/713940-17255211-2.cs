    public bool StartProcessAndWaitForExit(IProcessWrapper process, ProcessStartInfo info)
    {
        var process = process.Start(info); // injected wrapper interface makes method testable
        //...
    }
