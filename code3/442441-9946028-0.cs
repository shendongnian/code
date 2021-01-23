    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        if (e.FullPath ==  @"C:\File\Test")
            Foo();
    }
    
    private void Foo()
    {
        // Do something here 
    }
