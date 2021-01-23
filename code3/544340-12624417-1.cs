    public static void Encode(string path, string text)
    {
        // This StreamWriter constructor defaults to UTF-8
        using (StreamWriter writer = new StreamWriter(path))
            writer.Write(text);
    }
