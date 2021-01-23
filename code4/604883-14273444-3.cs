    public SpanFileReader(string filePath)
    {
        // ...
        _fileWrapper = IocContainer.Instance.Container.Resolve<IFileWrapper>();
    }
    public void MoveFileToErrorFolder(string spanFileName)
    {
        // ...
        if (_fileWrapper.Exists(spanFilePath))
        {
           // ...
        }
    }
 
