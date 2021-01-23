	public static void Main()
	{
		using (Process process = new Process())
		{
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.FileName = "cmd.exe";
			
			// Redirects the standard input so that commands can be sent to the shell.
			process.StartInfo.RedirectStandardInput = true;
			// Runs the specified command and exits the shell immediately.
			//process.StartInfo.Arguments = @"/c ""dir""";
	
			process.OutputDataReceived += ProcessOutputHandler;
			process.ErrorDataReceived += ProcessOutputHandler;
	
			process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
			
			// Send a directory command and an exit command to the shell
			process.StandardInput.WriteLine("dir");
			process.StandardInput.WriteLine("exit");
			
			process.WaitForExit();
		}
	}
	
	public static void ProcessOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
	{
		Console.WriteLine(outLine.Data);
	}
	public static void ProcessErrorHandler(object sendingProcess, DataReceivedEventArgs outLine)
	{
		Console.WriteLine(outLine.Data);
	}
