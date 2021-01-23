    private readonly IFileSystem _fileSystem; // this is from System.IO.Exception
    // This is assuming dependency injection to insert the mock file system during testing, 
    // or the real one in production
    public YourConstructor(IFileSystem fileSystem)
    {
       _fileSystem = fileSystem;
    }
    private Connection LoadConnectionDetailsFromDisk(string bodyFile)
    {     
       using (Stream fs = _fileSystem.FileStream.Create(bodyFile, FileMode.Open))
       {
           return this.serverConfiguration.LoadConfiguration(fs, flowProcess);
       }
       //more logic
    }
