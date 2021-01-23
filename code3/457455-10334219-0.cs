            Process[] processes = Process.GetProcesses();
            int i = 0;
            foreach (Process p in processes)
            {
                if (p.ProcessName.Contains("WinWord"))
                {
                    try
                    {
                        ProcessModuleCollection modules = p.Modules;
                        for (int j = 0; j <= modules.Count - 1; j++)
                        {
                            string sFile = modules[j].FileName;//can be needed file
                        }
                    }
                    catch (Exception exception)
                    {
                        //MsgBox(("Error : " & exception.Message)) 
                    }
                }
            }
