        /// <summary>
        /// Starts and returns result from console application. Execution is done without window.
        /// </summary>
        /// <param name="exePath">Full path to console exe file</param>
        /// <param name="arguments">console exe parameters</param>
        /// <returns></returns>
        static string ReadConsoleResult(string exePath, string arguments)
        {
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(exePath, arguments);
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            Process p = Process.Start(startInfo);
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }
