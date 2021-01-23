    string filePath = "your_file_path";
    var match = System.Text.RegularExpressions.Regex.Match(
        System.IO.File.ReadAllText(filePath),
        @"GeneratedNumber=""(\d+)""",
        System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    int num = match.Success ? int.Parse(match.Groups[1].Value) : 0;
