    if (IsProcessRunning(ServerProcessName)) { return; }
			var p = new Process
			{
				StartInfo = new ProcessStartInfo
				                {
				                    FileName = path,
                                    RedirectStandardOutput = true, 
                                    UseShellExecute = false
				                }
			};
			p.Start();
			var a = "";
			while (!a.Contains("ServicesStarted"))
			{
			    a = p.StandardOutput.ReadLine();
			}
