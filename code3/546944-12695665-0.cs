    [TestCase(".gz")]
    [TestCase(".gz.zip")]
    [TestCase(".gz.SO.jpg")]
    public void TestName(string extension)
    {
        FileInfo info = new FileInfo(@"C:/testfile.txt"+extension);
        string actual = info.Extension;
        Assert.AreEqual(actual,extension);
    }
