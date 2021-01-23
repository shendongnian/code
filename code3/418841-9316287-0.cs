    foreach (Process clsProcess in Process.GetProcesses())
    {
      if (clsProcess.ProcessName.Equals("EXCEL"))
      {
        clsProcess.Kill();
        break;
      }
    }
