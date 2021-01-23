    static string CorrectText(string input)
    {
        var winencoding = Encoding.GetEncoding("windows-1252");
        return Regex.Replace(input, "â€.",
            m => Encoding.UTF8.GetString(winencoding.GetBytes(m.Value)));
    }
