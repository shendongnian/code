    public int GetFilesInSubfolders(string directory)
    {
        var files = Directory.GetFiles(directory, "*.txt", SearchOption.AllDirectories));
        var (var i = 0; i < files.Length; i++)
        {
            load(files[i]);
            updateProgress(i); 
        }
        return files.Length;
    }
