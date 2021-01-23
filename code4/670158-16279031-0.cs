        public static string ShellProcessCommandLine(string cmdLineArgs,string path)
        {
            var sb = new StringBuilder();
            var pSpawn = new Process
            {
                StartInfo =
                    {
                        WorkingDirectory = path, 
                        FileName = "cmd.exe", 
                        CreateNoWindow = true,
                        Arguments = cmdLineArgs,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false
                    }
            };
            pSpawn.OutputDataReceived += (sender, args) => sb.AppendLine(args.Data);
            pSpawn.Start();
            pSpawn.BeginOutputReadLine();
            pSpawn.WaitForExit();
            return sb.ToString();
        }
