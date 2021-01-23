    var proc = new Process()
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "tasklist",
            Arguments = "/V",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        }
    };
    proc.Start();
    StreamReader sr = proc.StandardOutput;
    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();
        Match m = Regex.Match(line, @".{52}(\d+).{94}(.+)$");//157
        if (m.Success)
        {
            int session = Convert.ToInt32(m.Groups[1].Value);
            string title = m.Groups[2].Value.Trim();
            if (session == 1 && title != "N/A") sb.AppendLine(title);
        }
    }
