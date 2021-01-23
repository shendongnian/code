        private Process startProcessWithOutput(string command, string args, bool showWindow)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(command, args);
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = !showWindow;
            p.ErrorDataReceived += (s, a) => addLogLine(a.Data);
            p.Start();
            p.BeginErrorReadLine();
            return p;
        }
