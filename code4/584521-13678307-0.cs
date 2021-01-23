    //Class B
    public static FileInfo myFileProperty
    {
       get;
       set;
    }
    
    public static bool myMethod(FileInfo file)
    {
    //some codes here
    myFileProperty = file;
    return false;
    }
    
    
    //Class A
    void OnChanged(object source, FileSystemEventArgs e)
    {
    
    XmlTextReader reader = new XmlTextReader(ClassB.myFileProperty);
    }
