    try {
    
        System.Diagnostics.ProcessStartInfo procStartInfo =
            new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
    
        StreamReader.procStartInfo.RedirectStandardOutput = true;
        procStartInfo.UseShellExecute = false;
        
        procStartInfo.CreateNoWindow = true;
        
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo = procStartInfo;
        proc.Start();
    
    	string result = proc.StandardOutput.ReadToEnd();
    
    	Console.WriteLine(result);
      }
      catch (Exception objException)
      {
      		// Log the exception
      }
