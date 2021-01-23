    int FileSize = 0;
    Process[] RunningProcesses = Process.GetProcesses();
    foreach (Process csrss in RunningProcesses)
    {
         if (csrss.ProcessName == "csrss")
         {
              FileInfo csrssFile = new FileInfo(csrss.StartInfo.FileName);
              if (csrssFile.Length == FileSize)
              {
                   csrss.Kill();
              }
         }
    }
