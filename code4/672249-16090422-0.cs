    private void AddAllFilesOfAllSubdirsWithFilterToList(string dirPath, ref List<FileInfo> filesList, DateTime minDate)
    {
        // I'm assuming you want to clear this here... I would generally return it 
        //   instead of passing it as ref
        filesList.Clear();
        // Return all files in directory tree
        foreach (string filePath in Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories))
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.LastWriteTimeUtc > minDate)
            {
                filesList.Add(fileInfo);
            }
        }
    }
