    static List<string> SearchFiles(params string[] patterns)
    {
        var result = new List<string>();
        var drives = DriveInfo.GetDrives();
        Parallel.ForEach(drives, drive =>
        {
            if (!drive.IsReady || drive.DriveType == DriveType.NoRootDirectory)
                return;
            var searchPatterns = patterns.Select(p => drive.RootDirectory + p);
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
                result.AddRange(strOutput.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries));
            }
        });
        return result;
    }
