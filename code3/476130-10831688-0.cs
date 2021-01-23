        public static void ProcessStart(string ExecutablePath, string sArgs, bool bWait)
	    {
			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			proc.EnableRaisingEvents = false;
			proc.StartInfo.FileName = ExecutablePath;
            if(sArgs.Length > 0)
                proc.StartInfo.Arguments = sArgs;
            
            proc.Start();
            if(bWait)
                proc.WaitForExit();
            if(ProcessLive(ExecutablePath))
				return true;
			else
				return false;            	
		
		}
