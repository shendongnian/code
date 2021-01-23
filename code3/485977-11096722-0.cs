    public static string ReadFile(string path int codepage)
    {
        return Encoding.GetEncoding(codePage)
            .GetString(File.ReadAllBytes(path));
    }
