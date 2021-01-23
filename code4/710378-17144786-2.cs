    [SecuritySafeCritical]
    public static void AppendAllText(string path, string contents)
    {
        if (path == null) {
            throw new ArgumentNullException("path");
        }
        if (path.Length == 0) {
            throw new ArgumentException(
                Environment.GetResourceString("Argument_EmptyPath"));
        }
        File.InternalAppendAllText(path, contents, StreamWriter.UTF8NoBOM);
    }
