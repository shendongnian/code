    public static bool TryWriteText(string path, string text, TimeSpan timeout)
    {
        Contract.Requires(path != null); // Or replace with: if (path == null) throw new ArgumentNullException("path");
        Contract.Requires(text != null); // Or replace with: if (text == null) throw new ArgumentNullException("text");
        Stopwatch stopwatch = Stopwatch.StartNew();
        while (stopwatch.Elapsed < timeout)
        {
            try
            {
                File.WriteAllText(path, text);
                return true;
            }
            catch (IOException){} // Ignore IOExceptions until we time out, then return false.
            Thread.Sleep(100); // 100ms is rather short - it could easily be 1000 I think.
        }                      // Perhaps this should be passed in as a parameter.
        return false;
    }
