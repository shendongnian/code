    private string GetFtpName(string line)
    {
        for (int i = 0; i < 8; i++)
            line = line.Substring(line.IndexOf(" ")).Trim();
        return line;
    }
