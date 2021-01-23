    // Get all instances of Notepad running on the local 
    // computer.
    Process [] localByName = Process.GetProcessesByName("notepad");
    foreach(Process proc in localByName)
    {
        // Do something with the process ID
        proc.Id;
    }
