    private static DirectoryInfo _extractionFolder;
    public void Foo()
    {
        string _extractionFolder;
        ...
        _extractionFolder = @"C:\TEST"; // Modifies local variable, not static one
    }
