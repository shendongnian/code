    try
    {
        string workDir = Path.GetDirectoryName(command);
        string fileCmd = Path.GetFileName(command);
        System.Diagnostics.ProcessStartInfo procStartInfo =
            new System.Diagnostics.ProcessStartInfo("cmd", "/c " + fileCmd);
        procStartInfo.WorkingDirectory = workDir;
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.UseShellExecute = false;
        procStartInfo.CreateNoWindow = true;
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo = procStartInfo;
        proc.Start();
        proc.WaitForExit();
    }
    catch (Exception objException)
    {
        // Log the exception
    }
