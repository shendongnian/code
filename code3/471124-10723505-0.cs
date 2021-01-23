    static void Main(string[] args)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo()
            {
                FileName = "OutputRedirectionWorker.exe",
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            Process subProcess = new Process()
            {
                StartInfo = processInfo
            };
            subProcess.OutputDataReceived += 
                new DataReceivedEventHandler(OutputHandler);
            subProcess.Start();
            subProcess.BeginOutputReadLine();
            while (Console.ReadLine().ToLower() != "quit") {
                // looping here waiting for the user to type quit
            }
        }
