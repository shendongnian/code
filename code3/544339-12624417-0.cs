    public static string Decode(string path)
    {
        // This StreamReader constructor defaults to UTF-8
        using (StreamReader reader = new StreamReader(path))
            return reader.ReadToEnd();
    }
