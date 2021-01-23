    if(Directory.GetCurrentDirectory()!=dir)
    {
      string exepath = Path.Combine(dir,name);
      ProcessStartInfo processStartInfo = new ProcessStartInfo();
      process.StartInfo.FileName = exepath;
      processStartInfo.WorkingDirectory = dir;
      //Set your other process info properties
      Process process = Process.Start(processStartInfo);
      System.Environment.Exit(System.Environment.ExitCode);
    }
