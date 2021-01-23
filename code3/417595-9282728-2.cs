    using System;
    using System.Diagnostics;
    public static class Program
    {
        public static void Main()
        {
            var output = RunProcess();
            Console.WriteLine(output);
        }
        /// <summary>
        /// Runs the process: starts it and waits upon its completion.
        /// </summary>
        /// <returns>
        /// Standart output content as a string.
        /// </returns>
        private static string RunProcess()
        {
            using (var process = CreateProcess())
            {
                process.Start();
                // To avoid deadlocks, always read the output stream first and then wait.
                // For details, see: [Process.StandardOutput Property (System.Diagnostics)](https://msdn.microsoft.com/en-us/library/system.diagnostics.process.standardoutput(v=vs.110).aspx).
                var output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return output;
            }
        }
        private static Process CreateProcess()
        {
            return new Process
                {
                    StartInfo =
                        {
                            FileName = "netsh",
                            Arguments = "wlan show hostednetwork",
                            UseShellExecute = false,
                            RedirectStandardOutput = true
                        }
                };
        }
    }
