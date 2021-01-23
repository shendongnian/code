    public List<string> GetMusicFiles(string directory)
    {
        List<string> songPaths = new List<string>();
        // TODO: pick a better search pattern
        string[] paths = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
        foreach (string path in paths)
        {
            if (IsMusicFile(path))
            {
                songPaths.Add(path);
            }
        }
    }
