    private void SysInfo32()
    {
        Process proc = new Process();
        proc.EnableRaisingEvents = true;
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.FileName = "cmd.exe";
        proc.StartInfo.CreateNoWindow = true;
        proc.StartInfo.WorkingDirectory = contentDirectory;
        proc.StartInfo.Arguments = "/C systeminfo.exe> sysinfo.txt";
        proc.Start();
        proc.WaitForExit();
        proc.Close();
    }
