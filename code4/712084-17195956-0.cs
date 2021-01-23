    const string dataLine = "^([a-z0-9_\-]+)(\s*)(,\s*[a-z0-9_\-]+)*$";
    Regex validCSVDataPattern = new Regex(csvDataFormat, RegexOptions.IgnoreCase);
    protected override bool IsCorrectDataFormat(string fileContents)
    {
        string[] lines = fileContents.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        foreach (var line in lines)
        {
            if (!validCSVDataPattern.IsMatch(line))
            return false;
        }
        return true;
    }
