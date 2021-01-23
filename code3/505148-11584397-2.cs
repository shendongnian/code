    public static string UnescapeCodes(string src) {
        var rx = new Regex("\\\\([0-9A-Fa-f]+)");
        var res = new StringBuilder();
        var pos = 0;
        foreach (Match m in rx.Matches(src)) {
            res.Append(src.Substring(pos, m.Index - pos));
            pos = m.Index + m.Length;
            res.Append((char)Convert.ToInt32(m.Groups[1].ToString(), 16));
        }
        res.Append(src.Substring(pos));
        return res.ToString();
    }
