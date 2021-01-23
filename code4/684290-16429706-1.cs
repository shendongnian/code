    public List<string> GetMusicFiles(string directory)
    {
        List<string> songPaths = new List<string>();
        GetMusicFilesHelper(directory, songPaths);
        return songPaths;
    }
    private void GetMusicFilesHelper(string directory, List<string> paths)
    {
        string[] localFiles = Directory.GetFiles(directory);
        for(int i = 0; i < localFiles.Length; i++) 
        {
            if(isMusicFile(localFiles[i])) paths.Add(localFiles[i]);
        }
        string[] localFolders = Directory.GetDirectories(directory);
        for(int i = 0; i < localFolder.length; i++)
        {
            GetMusicFilesHelper(localFolder[i], paths);
        }
    }
