    /// <summary>
    /// Executes command
    /// </summary>
    /// <param name="cmd">command to be executed</param>
    /// <param name="output">output which application produced</param>
    /// <param name="transferPathEnvVar">true - if retain PATH environment variable from executed command</param>
    /// <returns>true if process exited with code 0</returns>
    static bool ExecCmd(string cmd, out String output, bool transferPathEnvVar = false)
    {
        int exitCode;
        ProcessStartInfo processInfo;
        Process process;
        if (transferPathEnvVar)
            cmd =  cmd + " && echo --VARS-- && set PATH";
        processInfo = new ProcessStartInfo("cmd.exe", "/c " + cmd);
        processInfo.CreateNoWindow = true;
        processInfo.UseShellExecute = false;
        processInfo.RedirectStandardError = true;
        processInfo.RedirectStandardOutput = true;
        process = Process.Start(processInfo);
        // Executing long lasting operation in batch file will hang the process, as it will wait standard output / error pipes to be processed.
        // We process these pipes here asynchronously.
        StringBuilder so = new StringBuilder();
        process.OutputDataReceived += (sender, args) => { so.AppendLine(args.Data); };
        StringBuilder se = new StringBuilder();
        process.ErrorDataReceived += (sender, args) => { se.AppendLine(args.Data); };
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();
        output = so.ToString();
        String error = se.ToString();
        if (transferPathEnvVar)
        {
            Regex r = new Regex("--VARS--(.*)", RegexOptions.Singleline);
            var m = r.Match(output);
            if (m.Success)
            {
                output = r.Replace(output, "");
                foreach ( Match m2 in new Regex("(.*?)=(.*)", RegexOptions.Multiline).Matches(m.Groups[1].ToString()) )
                {
                    String key = m2.Groups[1].Value;
                    String value = m2.Groups[2].Value;
                    Environment.SetEnvironmentVariable(key, value);
                }
            }
        }
        if(error.Length != 0)
            output += error;
        exitCode = process.ExitCode;
        if (exitCode != 0)
            Console.WriteLine("Error: " + output + "\r\n" + error);
        process.Close();
        return exitCode == 0;
    }
