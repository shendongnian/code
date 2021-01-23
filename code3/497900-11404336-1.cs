    foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName == "explorer")
                {
                    myProc.Kill();
                }
            }
