    private static void RunExecutable(string executable, string arguments) 
    {
       ProcessStartInfo starter = new ProcessStartInfo(executable, arguments);
       starter.CreateNoWindow = true;
       starter.RedirectStandardOutput = true;
       starter.UseShellExecute = false;
       Process process = new Process();
       process.StartInfo = starter;
       process.Start();
      StringBuilder buffer = new StringBuilder();
      using (StreamReader reader = process.StandardOutput) 
      {
        string line = reader.ReadLine();
        while (line != null) 
        {
          buffer.Append(line);
          buffer.Append(Environment.NewLine);
          line = reader.ReadLine();
          Thread.Sleep(100);
        }
      }
      if (process.ExitCode != 0) 
     {
        throw new Exception(string.Format(@"""{0}"" exited with ExitCode {1}. Output: {2}", 
    executable, process.ExitCode, buffer.ToString());  
     }
