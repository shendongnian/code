    public int IterateDirectories(string root)
    {
        int count = 0;
        iterateDirectories(root, ref count);
        return count;
    }
    private void iterateDirectories(string root, ref int count)
    {
        foreach (string directory in Directory.EnumerateDirectories(root))
            iterateDirectories(directory, ref count);
        foreach (string file in Directory.EnumerateFiles(root, "*.*"))
        {
            // load(file);
            ++count;
            // Now count is the actual number of files processed,
            // so you can use it for updateProgress()
        }
    }
