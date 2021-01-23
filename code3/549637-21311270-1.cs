        ///-----------------------------------------------------------------------------
        /// <summary>
        /// Gets the Process that's holding the clipboard
        /// </summary>
        /// <returns>A Process object holding the clipboard, or null</returns>
        ///-----------------------------------------------------------------------------
        public Process ProcessHoldingClipboard()
        {
            Process theProc = null;
            IntPtr hwnd = GetOpenClipboardWindow();
            if (hwnd != IntPtr.Zero)
            {
                uint processId;
                uint threadId = GetWindowThreadProcessId(hwnd, out processId);
                Process[] procs = Process.GetProcesses();
                foreach (Process proc in procs)
                {
                    IntPtr handle = proc.MainWindowHandle;
                    if (handle == hwnd)
                    {
                        theProc = proc;
                    }
                    else if (processId == proc.Id)
                    {
                        theProc = proc;
                    }
                }
            }
            return theProc;
        }
