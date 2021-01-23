    [TestMethod]
    public void TestStuff()
    {
        try
        {
            string o = null; // pretend this came from some real code
            var x = o.Split(new[] { ',' }); // this will throw NullRefException
        }
        catch (Exception e)
        {
            throw new AssertFailedException(e.Message, e);
        }
    }
