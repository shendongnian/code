    DirectoryInfo info = new DirectoryInfo(path);
    
    ProcessStartInfo processInfo = new ProcessStartInfo();
    processInfo.FileName = [you WinForms app];
    processInfo.Arguments = String.Format(@"""{0}""", info.FullName);
    using (Process process = Process.Start(processInfo))
    {
      process.WaitForExit();
    }
