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
            process.Start();
            // Register for event and do whatever
            process.OutputDataReceived += new DataReceivedEventHandler((snd, e) => { consoleOut += e.Data; });
            process.WaitForExit();
            return consoleOut;
        }
    }
