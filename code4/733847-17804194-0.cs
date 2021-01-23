    public async Task<string> ReadFromFile(string filename)
    {
        IFolder rootFolder = FileSystem.Current.LocalStorage;
        IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder", 
            CreationCollisionOption.OpenIfExists);
        IFile file = await folder.GetFileAsync(filename);
        string content = await file.ReadAllTextAsync();
        return content;
    }
