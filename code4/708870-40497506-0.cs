    public static void RunRemoteCommand(string command, string RemoteMachineName, 
                                        string username,string password)
    {
    
    
                var connection = new ConnectionOptions();
                connection.Username = username;
                connection.Password = password;
    
    
        ManagementScope WMIscope = new ManagementScope(
            String.Format("\\\\{0}\\root\\cimv2", RemoteMachineName), connection);
        WMIscope.Connect();
        ManagementClass WMIprocess = new ManagementClass(
            WMIscope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
        object[] process = { command };
        object result = WMIprocess.InvokeMethod("Create", process);
        Log.Comment("Creation of process returned: " + result);
    }
