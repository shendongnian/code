    static string[] SearchFiles(params string[] patterns)
    {
        var searchPatterns = DriveInfo.GetDrives()
            .Where(d => d.IsReady && d.DriveType != DriveType.NoRootDirectory)
            .SelectMany(d => patterns.Select(p => d.RootDirectory + p));
            
        using (var process = new Process())
        {
            process.StartInfo.FileName = Path.Combine(Environment.SystemDirectory, "cmd.exe");
            process.StartInfo.Arguments = "/C dir " + String.Join(" ", searchPatterns) + " /s/b";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            string strOutput = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return strOutput.Split(Environment.NewLine.ToArray());
        }
    }
