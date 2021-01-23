       foreach (Process clsProcess in Process.GetProcesses())
       {
          if (clsProcess.ProcessName.Equals("EXCEL")&& clsProcess.MainWindowTitle =="example")  
          {
              clsProcess.CloseMainWindow();
              break;
          }
       }
