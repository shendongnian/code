    public static class SystemProcess
	{
		private static string output;
		private static string error;
		private static string password;
		public static void Start (string filename, string arguments)
		{
			ProcessStartInfo startInfo = SystemProcess.Prepare(filename, arguments);
			using (Process process = Process.Start(startInfo)) {
				SystemProcess.output = process.StandardOutput.ReadToEnd();
				SystemProcess.error = process.StandardError.ReadToEnd();
				process.WaitForExit();
			}
		}
		public static void StartPrivileged (string filename, string arguments)
		{
			ProcessStartInfo startInfo;
			if (SystemProcess.password == default(string))
			{
				startInfo = SystemProcess.Prepare("gksudo", "-p true -D 'MyApplication'");
				using (Process process = Process.Start(startInfo)) {
					SystemProcess.password = process.StandardOutput.ReadToEnd();
					process.WaitForExit();
				}
			}
			startInfo = SystemProcess.Prepare("sudo", "-S " + filename + " " + arguments);
			using (Process process = Process.Start(startInfo)) {
				process.StandardInput.WriteLine(SystemProcess.password);
				SystemProcess.output = process.StandardOutput.ReadToEnd();
				SystemProcess.error = process.StandardError.ReadToEnd();
				process.WaitForExit();
			}
		}
		private static ProcessStartInfo Prepare (string filename, string arguments)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo (filename, arguments);
			startInfo.RedirectStandardError = true;
			startInfo.RedirectStandardOutput = true;
			startInfo.RedirectStandardInput = true;
			startInfo.UseShellExecute = false;
			return startInfo;
		}
		public static string Output {
			get {
				return SystemProcess.output;
			}
		}
		public static string Error {
			get {
				return SystemProcess.error;
			}
		}
	}
