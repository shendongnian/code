	[DllImport("kernel32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	static extern bool AllocConsole();
	
	[DllImport("kernel32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	static extern bool FreeConsole();
	
	private static void Main(string[] args)
	{
		Process p = new Process();
		p.StartInfo.UseShellExecute = false;
		p.StartInfo.CreateNoWindow = false;
		p.StartInfo.RedirectStandardOutput = true;
		p.StartInfo.RedirectStandardError = false;
		
		p.StartInfo.FileName = "Child.exe";
		p.StartInfo.Arguments = "i";
		
		AllocConsole();
		p.Start();
		FreeConsole();
		string processOutput = p.StandardOutput.ReadToEnd();
		p.WaitForExit();
		Debug.WriteLine("The child process output is:" + processOutput);
	}
