    public static void TurnOffFireWall()
    {
        // Have only been tested in Win10
        Process proc = new Process();
        string top = "netsh.exe";
        proc.StartInfo.Arguments = "advfirewall set allprofiles state off";
        proc.StartInfo.FileName = top;
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.CreateNoWindow = true;
        proc.Start();
        proc.WaitForExit();
    }
