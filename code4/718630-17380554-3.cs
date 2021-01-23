    private static void InternalWriteAllText(string path,
        string contents, Encoding encoding)
    {
        Contract.Requires(path != null);
        Contract.Requires(encoding != null);
        Contract.Requires(path.Length > 0);
        using (StreamWriter sw = new StreamWriter(path, false, encoding))
            sw.Write(contents);
    }
