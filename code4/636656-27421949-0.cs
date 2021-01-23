    bool checkSingleInstance()
        {
            string procName = Process.GetCurrentProcess().ProcessName;
            // get the list of all processes by that name
            Process[] processes = Process.GetProcessesByName(procName);
            if (processes.Length > 1)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
