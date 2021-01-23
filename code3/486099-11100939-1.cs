    private static readonly DirectoryInfo MyDirectory;
    
    static MyClass()
    {
    	Contract.Requires(Settings.Default.MyDirectoryPath != null);
    	MyDirectory = new DirectoryInfo(Settings.Default.MyDirectoryPath);
    }
    
    protected void SomeMethod()
    {
    	SomeOtherMethod(MyDirectory);
    }
    
    protected virtual void SomeOtherMethod(DirectoryInfo directory)
    {
    	Contract.Requires(directory.Exists && !String.IsNullOrEmpty(directory.FullName));
    
    	var catalog = new DirectoryCatalog(directory.FullName);
    }
