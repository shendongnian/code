        string command = string.Format("{0}\\Make\\copyf.cmd {1}", Properties.Settings.Default.pathTo , com);
        int waitTime = 60000; //1 min as example here
        using (var process = new Process()
        {
        	StartInfo = new ProcessStartInfo()
        			{
        				UseShellExecute = false,
        				RedirectStandardOutput = true,
        				CreateNoWindow = true,
        				RedirectStandardInput = true,
        				RedirectStandardError = true,
        				FileName = "cmd.exe",
        				Arguments = string.Format("/C \"{0}\"", command)
        			}
        })
        {
        	try
        	{
        		if (!process.Start())
        		{
        			//Log some error "Failed to run command";
        		}
        	}
        	catch (Exception ex)
        	{
        		//Log some error "Failed to start process command";
        	}
        
        	process.BeginOutputReadLine();
        	string error = process.StandardError.ReadToEnd();
        	process.WaitForExit(waitTime);
        	if (!process.HasExited)
        	{
        		//Log something "Command: did not finish in time, terminating process"
        		try
        		{
        			process.Kill();
        		}
        		catch { }
        	}	
        }
    
        
