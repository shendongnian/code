    private void TakeOverAllScreens()
    {
        int i = 0;
        List<Process> allProcesses = new List<Process>();
        foreach (Screen s in Screen.AllScreens)
        {
            if (s != Screen.PrimaryScreen)
            {
                i++;
               allProcesses.Add(Process.Start(Application.ExecutablePath, "Screen|" + s.Bounds.X + "|" + s.Bounds.Y + "|" + i));
            }
        }
   
        foreach (Process proc in allProcesses)
        {
            proc.Kill();
        }
    }
