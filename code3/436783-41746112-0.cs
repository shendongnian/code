    using System.Diagnostics;
    
      public bool FindAndKillProcess(string name)
            {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.Contains(name))
                    {
                        //To know if it works
                        //MessageBox.Show(clsProcess);
                        clsProcess.Kill();
                        return true;
                    }
                }
                //process not found, return false
                return false;
            }
    
    ////// call the function:
    
                FindAndKillProcess("AcroRd32");
    ////// if you have been saved all the variables also you can close you main form
                FindAndKillProcess("Form_Name");
