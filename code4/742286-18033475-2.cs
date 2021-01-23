    private bool IsProcessRunning(string name)
    {
         foreach (Process p in Process.GetProcesses())
         {
                if (p.ProcessName.Contains(name))
                {
                    return true;
                }
          }
          return false;
     }
