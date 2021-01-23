    public static void RunFromCmd(string batch, params string[] args)
    {
    	// Not required. But our R scripts use allmost all CPU resources if run multiple instances
    	lock (typeof(REngineRunner))
    	{
    		string file = string.Empty;
    		string result = string.Empty;
    		try
    		{
    			// Save R code to temp file
    			file = TempFileHelper.CreateTmpFile();
    			using (var streamWriter = new StreamWriter(new FileStream(file, FileMode.Open, FileAccess.Write)))
    			{
    				streamWriter.Write(batch);
    			}
    			
    			// Get path to R
    			var rCore = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\R-core") ??
    						Registry.CurrentUser.OpenSubKey(@"SOFTWARE\R-core");
    			var is64Bit = Environment.Is64BitProcess;
    			if (rCore != null)
    			{
    				var r = rCore.OpenSubKey(is64Bit ? "R64" : "R");
    				var installPath = (string)r.GetValue("InstallPath");
    				var binPath = Path.Combine(installPath, "bin");
    				binPath = Path.Combine(binPath, is64Bit ? "x64" : "i386");
    				binPath = Path.Combine(binPath, "Rscript");
    				string strCmdLine = @"/c """ + binPath + @""" " + file;
    				if (args.Any())
    				{
    					strCmdLine += " " + string.Join(" ", args);
    				}
    				var info = new ProcessStartInfo("cmd", strCmdLine);
    				info.RedirectStandardInput = false;
    				info.RedirectStandardOutput = true;
    				info.UseShellExecute = false;
    				info.CreateNoWindow = true;
    				using (var proc = new Process())
    				{
    					proc.StartInfo = info;
    					proc.Start();
    					result = proc.StandardOutput.ReadToEnd();
    				}
    			}
    			else
    			{
    				result += "R-Core not found in registry";
    			}
    			Console.WriteLine(result);
    		}
    		catch (Exception ex)
    		{
    			throw new Exception("R failed to compute. Output: " + result, ex);
    		}
    		finally
    		{
    			if (!string.IsNullOrWhiteSpace(file))
    			{
    				TempFileHelper.DeleteTmpFile(file, false);
    			}
    		}
    	}
    }
