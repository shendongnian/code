    public static string ReadFile(string path, byte[] translationTable, int codepage)
    {
        byte[] content = File.ReadAllBytes(path);
        for (int i=0; i < content.Length; ++i)
        {
            byte value = content[i];
            if (value > 127)
                content[i] = translationTable[value - 128];
        }
        return Encoding.GetEncoding(codepage)
            .GetString(content);
    }
