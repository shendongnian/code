    public IList<String> GetMatchingRemoteFiles(String SearchPattern, bool ignoreCase)
    {
        var options = ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
        return thirdPartyTool.ftpClient.GetCurrentDirectoryContents()
                             .Where(fn => Regex.Matches(fn, SearchPattern, options))
                             .ToList();
    }
