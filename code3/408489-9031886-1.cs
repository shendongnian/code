    [Test]
    public void Test()
    {
        string expected = "this is my test string";
        string a = expected.Crypt();
        Debug.WriteLine(a);
        string actual = a.Decrypt();
        Assert.AreEqual(expected, actual);
    }
