    foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName.Contains("explorer"))
                {
                    myProc.Kill();
                }
            }
