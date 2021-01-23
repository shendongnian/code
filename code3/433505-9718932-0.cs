    public bool IsMacOS(string userAgent)
    {
        var osInfo = userAgent.Split(new Char[] { '(', ')' })[1];
        return osInfo.Contains("Mac_PowerPC") || osInfo.Contains("Macintosh");
    }
