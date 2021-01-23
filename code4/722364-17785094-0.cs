    using (var p = new Process())
    {
    	p.StartInfo = new ProcessStartInfo("msbuild")
    	{
    		UseShellExecute = false,
    		CreateNoWindow = true,
    		RedirectStandardError = true,
    		RedirectStandardOutput = true,
    	};
    	p.ErrorDataReceived += (s, e) => ErrorLine(e.Data);
    	p.OutputDataReceived += (s, e) => OutputLine(e.Data);
    	p.BeginErrorReadLine();
    	p.BeginOutputReadLine();
    	p.Start();
    	p.WaitForExit();
    }
    void ErrorLine(string text)
    {
    	Console.ForegroundColor = ConsoleColor.White;
    	Console.BackgroundColor = ConsoleColor.DarkRed;
    	Console.Error.WriteLine(text);
    	Console.ResetColor();
    }
    void OutputLine(string text)
    {
    	Console.Error.WriteLine(text);
    }
