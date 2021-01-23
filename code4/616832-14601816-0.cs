    private readonly Func<IOpenFileService> openFileServiceFactory;
    
    private string SelectFile(string initialDirectory)
    {
        var openFileService = this.openFileServiceFactory();
        if (Directory.Exists(initialDirectory))
        {
            openFileService.InitialDirectory = initialDirectory;
        }
        else
        {
            openFileService.InitialDirectory =
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        }
        bool? result = openFileService.ShowDialog();
        if (result.HasValue && result.Value)
        {
            return openFileService.FileName;
        }
        return null;
    }
