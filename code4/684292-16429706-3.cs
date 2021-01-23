    public IEnumerable<string> GetMusicFiles(string directory)
    {
        return Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories)
                        .Where(ff => IsMusicFile(ff));
    }
