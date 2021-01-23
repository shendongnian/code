    System.Diagnostics.Process proc;
    cmd = "/C ping example.com -t -l 65000";
    for (i = 0; i < 5; i++)
    {
        proc = new System.Diagnostics.Process();
        proc.EnableRaisingEvents = false;
        proc.StartInfo.FileName = "cmd";
        proc.StartInfo.Arguments = cmd;
        proc.Start();
    }
