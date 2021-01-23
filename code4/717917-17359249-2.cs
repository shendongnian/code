    [TestMethod]
    public void DeleteFileSuccessFul()
    {
        string fileName = "c:\\Temp\\UnitTest3.txt";
        FileInfo fileInfo = new FileInfo(fileName);
        FileStream fileStream = null;
        try
        {
            fileStream = File.Create(Path.Combine(fileName));
        }
        finally
        {
            if (fileStream != null)
                fileStream.Dispose();
        }
        bool success = FileActions.DeleteFile(fileInfo);
        Assert.IsTrue(success);
    }
 
