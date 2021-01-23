    string executableDir = Path.GetDirectoryName(Application.ExecutablePath);
    string launchFile = Path.Combine(executableDir, "launch.txt"));
    string[] lines = File.ReadAllLines(launchFile);
    // Fill the dictionary with the game name as key and the path as value.
    _games = lines
        .Where(l => !String.IsNullOrWhitespace(l))
        .Select(l => l.Split('='))
        .ToDictionary(s => s[0].Trim(), s => s[1].Trim());
