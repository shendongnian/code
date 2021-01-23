    var proc = Process.GetProcesses()
                      .Where(p => p.MainWindowTitle.Contains(Text))
                      .FirstOrDefault();
    
            if (proc != null)
            {
                FocusWindow(p.MainWindowTitle);
                Application.Exit();
            }
