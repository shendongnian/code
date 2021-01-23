    public string executeCommand(string serverName, string username, string password, string domain=null, string command)
    {
    	try
    	{
    		System.Diagnostics.Process process = new System.Diagnostics.Process();
    		System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    		startInfo.RedirectStandardOutput = true;
    		startInfo.UseShellExecute = false;
    		startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    		startInfo.FileName = "cmd.exe";
    		if (null != username)
    		{
    			if (null != domain)
    			{
    				startInfo.Arguments = "/C \"psexec.exe \\\\" + serverName + " -u " + domain+"\\"+username + " -p " + password + " " + command + "\"";
    			}
    			else
    			{
    				startInfo.Arguments = "/C \"psexec.exe \\\\" + serverName + " -u " + username + " -p " + password + " " + command + "\"";
    			}
    		}
    		else
    		{
    			startInfo.Arguments = "/C \"utils\\psexec.exe "+serverName+" "+ command + "\"";
    		}
    		process.StartInfo = startInfo;
    		process.Start();
    		process.WaitForExit();
    
    		if (process.ExitCode == 0 && null != process && process.HasExited)
    		{
    		   return process.StandardOutput.ReadToEnd();
    		}
    		else
    		{
    			return "Error running the command : "+command;
    		}
    	}
    	catch (Exception ex)
    	{
    		throw ex;
    	}
    }
