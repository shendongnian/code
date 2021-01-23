    string[] files = System.IO.Directory.GetFiles();
    
    NumericComparer ns = new NumericComparer();
    Array.Sort(files, ns);
    
    // files will now sorted in the numeric order
    // we can do the same for directories
    
    string[] dirs = System.IO.Directory.GetDirectories();
    ns = new NumericComparer(); // new object
    Array.Sort(dirs, ns);
