    var connOpts = new ConnectionOptions()
    {
    // Optional, default is to use current identity
        Username = "username",
        Password = "password"
    };
    // create a handle to the Win32_Process object on the remote computer
    ManagementScope mgmtScope = new ManagementScope(@"\\servername\root\cimv2", connOpts);
    ManagementClass w32Process = new ManagementClass(mgmtScope, 
        new ManagementPath("Win32_Process"), new ObjectGetOptions());
    // create the process itself
    object[] createArgs = new object[] {
        // [in]   string CommandLine,
        "notepad.exe", 
        // [in]   string CurrentDirectory,
        null, 
        // [in]   Win32_ProcessStartup ProcessStartupInformation,
        null, 
        // [out]  uint32 ProcessId
        0};
    var result = (int)w32Process.InvokeMethod("Create", createArgs);
    switch (result)
    {
        case 0: /* no-op, successful start */ break;
        case 2: throw new Exception("Access Denied");
        case 3: throw new Exception("Insufficient Privilege");
        case 8: throw new Exception("Unknown failure");
        case 9: throw new Exception("Path not found");
        case 21: throw new InvalidOperationException("Invalid Parameter");
    }
