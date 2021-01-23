    [DllImport("user32")]
    private static extern bool SetForegroundWindow(IntPtr hwnd);
    public static void Processing(string WorkingDirectory, string FileName, string Arguments, bool StandardOutput, string OutputFileName)
        {
            Process proc = new Process();
            proc.EnableRaisingEvents = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = StandardOutput;
            proc.StartInfo.FileName = FileName;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WorkingDirectory = WorkingDirectory;
            proc.StartInfo.Arguments = Arguments;
            proc.Start();
            //Added code
            System.Threading.Thread.Sleep(500);
            SetForegroundWindow(proc.MainWindowHandle);
            //........................................
            if (StandardOutput == true)
            {
                string output = proc.StandardOutput.ReadToEnd();
                DumpOutput(WorkingDirectory + "\\" + OutputFileName, output);
            }
            proc.WaitForExit();
            proc.Close();
        }
