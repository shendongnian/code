    public static string RunConsoleCommand(string command, string args)
    {
        var consoleOut = "";
        using (var process = new Process())
        {
            process.StartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };
            // Register for event and do whatever
            process.OutputDataReceived += new DataReceivedEventHandler((snd, e) => { consoleOut += e.Data; });
            process.Start();
            process.WaitForExit();
            return consoleOut;
        }
    }
