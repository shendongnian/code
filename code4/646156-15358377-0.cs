    public static StreamReader ExecuteCommandLine(String file, String arguments = "") 
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.CreateNoWindow = true;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.FileName = file;
        startInfo.Arguments = arguments;
     
        Process process = Process.Start(startInfo);
 
        return process.StandardOutput;
    }
