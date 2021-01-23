    public static string ReadFile(string path, byte[] translationTable, int codepage)
    {
        byte[] content = File.ReadAllBytes(path);
        for (int i=0; i < content.Length; ++i)
            content[i] = translationTable[content[i]];
        return Encoding.GetEncoding(codepage)
            .GetString(content);
    }
