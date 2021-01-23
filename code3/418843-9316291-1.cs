    foreach (Process clsProcess in Process.GetProcesses())
    {
        if (clsProcess.ProcessName.Equals("EXCEL") && HasFileHandle(fileName, clsProcess))
        {
           clsProcess.Kill();
           break;
        }
     }
