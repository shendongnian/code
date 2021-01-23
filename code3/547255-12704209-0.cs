    public string CurrentFileBuffer
    {
        get; private set;
    }
    public async void ReadTextFile(string Path)
    {
        var folder = Package.Current.InstalledLocation;
        var file = await folder.GetFileAsync(Path);
        var read = await FileIO.ReadTextAsync(file);
        CurrentFileBuffer = read;
    }
