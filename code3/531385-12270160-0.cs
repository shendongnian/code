        var exeName = @"tasklist.exe";
        var arguments = "";
        var process = new Process
        {
            EnableRaisingEvents = true,
            StartInfo = new ProcessStartInfo(exeName)
            {
                Arguments = arguments,
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            },
        };
        process.OutputDataReceived += 
           (sender, e) => Console.WriteLine("received output: {0}", e.Data);
        
        process.Start();
        process.BeginOutputReadLine();
        process.WaitForExit();
