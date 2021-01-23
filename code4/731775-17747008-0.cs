    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestFoo()
    {
        Type t = null;
        t.GetFoo();
    }
