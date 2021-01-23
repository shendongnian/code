        Process[] pname = Process.GetProcessesByName("communicator");
        while (pname.Length == 0) 
        {
            pname = Process.GetProcessesByName("communicator");
        }
        var getclient = LyncClient.GetClient();
