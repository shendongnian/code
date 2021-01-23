	/* This section is run in batch file mode
	%FrameworkDir%%FrameworkVersion%\csc.exe /nologo /out:bootstrap.exe /Reference:%FrameworkDir%%FrameworkVersion%\System.Net.dll "%0"
	goto end
	*/
	using System;
	using System.IO;
	using System.Net;
	static class Program
	{
		static void Main(string[] argv)
		{
			//Console.WriteLine("Do whatever you like here");
			var wc = new WebClient();
			using (var data = wc.OpenRead(argv[0]))
			{
				using (var reader = new StreamReader(data))
				{
					string s = reader.ReadToEnd();
					Console.WriteLine(s);
				}
			}
		}
	}
	/*
	:end
	REM ** Run the program
	BootStrap.exe "http://169.254.169.254/latest/meta-data/"
	REM */
