    private IEnumerable<string> ReadLineFromFile(string path)
    {
        byte[] ansiEncodedBytes = File.ReadAllBytes(path);
        Encoding ansi = Encoding.GetEncoding(1252);
        string utf16string = ansi.GetString(ansiEncodedBytes);
        return utf16string.Split("\n");
    }
