    [Test]
    public void SaveTextTest()
    {
        string relativePath=@"Errors\errorLog_";
        string directoryPath = System.IO.Path.Combine( System.IO.Directory.GetCurrentDirectory() , relativePath);
        var directoryInfo = new DirectoryInfo(directoryPath);
        if(directoryInfo.Exists==false)
            directoryInfo.Create();
        string fileName = System.DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".txt";
        string path = System.IO.Path.Combine(directoryPath, fileName);
        string textToSave = "This will be saved";
        File.WriteAllText(path, textToSave);       
    }
