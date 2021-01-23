    [TestCase("//a/img[@src='/Img1.png']")]
    [TestCase("//a/img[@src='/Img2.png']")]
    [TestCase("//a/img[@src='/Img3.png']")]
    public void ElementIsPresent(string xpath)
    {
        Assert.IsTrue(IsElementPresent(By.XPath(xpath)));
    }
