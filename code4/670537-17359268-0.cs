    public String GetActiveFileNameTitle()
        {
            IntPtr hWnd = GetForegroundWindow();
            uint procId = 0;
            GetWindowThreadProcessId(hWnd, out procId);
            var proc = Process.GetProcessById((int)procId);
            if (proc != null)
            {
               return proc.MainModule.FileVersionInfo.ProductName;
            }
            
        }
