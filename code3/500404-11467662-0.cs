        System.Management.ManagementObjectSearcher Processes = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_Process Where Name ='notepad.exe' ");
        string user = "JohnDoe";
        foreach (System.Management.ManagementObject process in Processes.Get())
        {
            if (process["ExecutablePath"] != null)
            {
                string[] OwnerInfo = new string[2];
                process.InvokeMethod("GetOwner", (object[])OwnerInfo);
                if (OwnerInfo[0] == user)
                {
                    process.Delete();
                }
            }
        }
