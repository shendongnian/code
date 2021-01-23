    [TestCase(@"C:/testfile.txt.gz", ".gz")]
    [TestCase(@"C:/testfile.txt.gz.zip", ".zip")]
    [TestCase(@"C:/testfile.txt.gz.SO.jpg", ".jpg")]
    public void TestName(string fileName, string expected)
    {
        FileInfo info = new FileInfo(fileName);
        string actual = info.Extension;
        Assert.AreEqual(actual, expected);
    }
