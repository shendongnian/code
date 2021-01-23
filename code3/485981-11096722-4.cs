    public static string ReadFile(string path, int codepage)
    {
        return Encoding.GetEncoding(codepage)
            .GetString(File.ReadAllBytes(path));
    }
