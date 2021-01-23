    private List<string> _allowedLocations
    public YourClassConstructor()
    {
       _allowedLocations = new List() 
       {@"\\SVR01\Dev", @"\\SVR02\Dev", @"\\SVR02\Dev"}
    }
    private FileInfo[] GetFileList(string pattern,string location)
    {
       if (location == null) 
          throw new ArgumentNullException("location");
       
       if (!_allowedLocations.Contains(location))
          throw new ArgumentOutOfRangeException("location");
           
       var di = new DirectoryInfo(@"\\SVR02\Dev");
       return di.GetFiles(pattern);
    }
