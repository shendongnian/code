    List<string> loggedInUsers = new List<string>();
    ManagementClass mc = new ManagementClass("Win32_Process");
    ManagementObjectCollection moc = mc.GetInstances();
    
    foreach (ManagementObject mo in moc)
    {
        ROOT.CIMV2.Process process = new ROOT.CIMV2.Process(mo);
        string domain, user;
        uint pid;
        process.GetOwner(out domain, out user);
        pid = process.ProcessId;
        if (process.Name.Trim().ToLower() == "explorer.exe")
            loggedInUsers.Add(user);
    }
    return loggedInUsers;
