    public static string ParseFile(string FilePath)
    {
        using (var streamReader = new StreamReader(FilePath))
        {
            return streamReader.ReadToEnd().Replace(Environment.NewLine, string.Empty).Replace(" ", string.Empty).Replace(',', ';');
        }
    }
