    int pid = 1234; //process id that you need to dump
    string dumpPath;
    dumpPath = @"C:\Programs\test.dmp";
    DbgControl dbgControl = new DbgControl();
    dbgControl.AttachToProcess(pid, @"C:\Programs\InjectLeakTrack.vbs", @"C:\", dumpPath);
    DbgObj dbgObj = new DbgObj();
    dbgObj.CreateDumpForProcessID(pid, "No reason", false, true);
    dbgControl.DetachFromProcess();
