			var pi = new ProcessStartInfo
			{
				FileName = prog,
				Arguments = args,
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = false
			};
			var proc = new Process { StartInfo = pi };
			try
			{
				if (!proc.Start())
				{
					throw new ApplicationException("Starting proc failed!");
				}
				Console.WriteLine(proc.StandardOutput.ReadToEnd());
				proc.WaitForExit();
				if (proc.ExitCode != 0)
				{
					//throw new ApplicationException(String.Format("proc returned exit code {0}", proc.ExitCode));
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Unknown problem in proc", ex);
			}
			finally
			{
				if (!proc.HasExited)
					proc.Kill();
			}
