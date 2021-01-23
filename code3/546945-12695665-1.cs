    [TestCase(".gz",".gz")]
    [TestCase(".gz.zip",".zip")]
    [TestCase(".gz.SO.jpg",".jpg")]
    public void TestName(string extension,string expected)
    {
        FileInfo info = new FileInfo(@"C:/testfile.txt"+extension);
        string actual = info.Extension;
        Assert.AreEqual(actual,expected);
    }
