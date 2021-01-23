    string input = textBox3.Text.Trim();
    Match match = Regex.Match(input,
        "^" +
        "(?:(?<d>[0-9]+)d)? *" +
        "(?:(?<h>[0-9]+)h)? *" +
        "(?:(?<m>[0-9]+)m)? *" +
        "(?:(?<s>[0-9]+)s)?" +
        "$");
    if (match.Success)
    {
        int d, h, m, s;
        Int32.TryParse(match.Groups["d"].Value, out d);
        Int32.TryParse(match.Groups["h"].Value, out h);
        Int32.TryParse(match.Groups["m"].Value, out m);
        Int32.TryParse(match.Groups["s"].Value, out s);
        // ...
    }
