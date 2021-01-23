    public string GetTracert(string ip)
    {
        Process p = new Process();
        p.StartInfo.FileName = "tracert";
        p.StartInfo.Arguments = "123.123.123.123";
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();
        return p.StandardOutput.ReadToEnd();
    }
