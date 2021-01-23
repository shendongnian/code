    // Note: include a reference to System.Text.RegularExpressions.
    Match m = Regex.Match(string2, @"(.*\s)([A-Z]+.[0-9]*)(\s.[A-Z]*\s)");
    string preText = m.Groups[1].Value;
    string streetName = m.Groups[2].Value;
    string postText = matches.Groups[4].Value;
    string city = matches.Groups[3].Value;
