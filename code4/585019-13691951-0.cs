    class Program
    {
        static void Main(string[] args)
        {
            var repos = args[0];
            var txn = args[1];
            var log = GetSvnLookOutput(repos, txn, "log");
            var changedPaths = GetSvnLookOutput(repos, txn, "changed");
            var logValidation = GetLogMessageErrors(log.Replace("\r", "").Replace("\n", ""));
            if (logValidation != null)
            {
                Console.Error.WriteLine(logValidation);
                Environment.Exit(1);
            }
            if (log.Contains("Autoversioning commit"))
            {
                // this is an autoversion webdav client, enforce path rules
                var changedPathsValidation = GetFileNameErrors(changedPaths);
                if (changedPathsValidation != null)
                {
                    Console.Error.WriteLine(changedPathsValidation);
                    Environment.Exit(1);
                }
            }
            Environment.Exit(0);
        }
        private static string GetLogMessageErrors(string log)
        {
            if (string.IsNullOrEmpty(log))
            {
                return "Log message is required.";
            }
            return null;
        }
        private static string GetFileNameErrors(string changedPaths)
        {
            var changeRows = Regex.Split(changedPaths.TrimEnd(), Environment.NewLine);
            foreach (var changeRow in changeRows)
            {
                var changeType = changeRow[0];
                var filePath = changeRow.Substring(4, changeRow.Length - 4);
                if (filePath.ToLower().Contains("/code/"))
                {
                    return "Autoversioning commits are not allowed inside /CODE/ folders. Use a SVN client for this.";
                }
            }
            return null;
        }
        private static string GetSvnLookOutput(string repos, string txn, string subcommand)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = @"svnlook.exe",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = String.Format("{0} -t \"{1}\" \"{2}\"", subcommand, txn, repos)
            };
            var process = Process.Start(processStartInfo);
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
    }
