        bool isRunning = false;
        foreach (Process clsProcess in Process.GetProcesses()) {
                if (clsProcess.ProcessName.Contains("iexplore"))
                {
                        isRunning = true;
                        break;
                }
        }
