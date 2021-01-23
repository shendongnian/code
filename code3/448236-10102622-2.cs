    public static string ParseFile(string FilePath)
    {
        using (StreamReader streamReader = new StreamReader(FilePath))
        {
            string text = streamReader.ReadToEnd().Replace(Environment.NewLine, string.Empty).Replace(" ", string.Empty).Replace(',', ';');
            streamReader.Close();
            return text;
        }
    }
