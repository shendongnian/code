    ProcessStartInfo info = new ProcessStartInfo();
    //Set info properties...
    Process process = new Process();
    process.StartInfo = info;
    //set other process properties...
    process.Start();
    process.WaitForExit();
