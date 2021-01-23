    public static string RemoveFirstLine(string input)
    {
        var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        return string.Join(Environment.NewLine, lines.Skip(1));
    }
