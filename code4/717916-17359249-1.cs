    [TestMethod]
    public void DeleteFileSuccessFul()
    {
        string fileName = "c:\\Temp\\UnitTest3.txt";
        FileInfo fileInfo = new FileInfo(fileName);
        using (File.Create(Path.Combine(fileName)))
        {
        }
        bool success = FileActions.DeleteFile(fileInfo);
        Assert.IsTrue(success);
    }
