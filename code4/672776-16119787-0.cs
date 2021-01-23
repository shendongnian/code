    int exitCode = RunProcessForExitCode(filename, arguments);
        private static int RunProcessForExitCode(string processFilename, string processArguments)
        {
            //make process output possible to machine-reading
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = processFilename,
                    Arguments = processArguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            Console.Write(process.StandardOutput.ReadToEnd());
            process.WaitForExit();
            return process.ExitCode;
        }
