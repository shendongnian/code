    public static void TryWriteText(string path, string text, TimeSpan timeout)
    {
        Contract.Requires(path != null); // Or replace with: if (path == null) throw new ArgumentNullException("path");
        Contract.Requires(text != null); // Or replace with: if (text == null) throw new ArgumentNullException("text");
        Stopwatch stopwatch = Stopwatch.StartNew();
        while (true)
        {
            try
            {
                File.WriteAllText(path, text);
            }
            catch (IOException)
            {
                if (stopwatch.Elapsed > timeout)
                    throw;
            }
            Thread.Sleep(100);
        }
    }
