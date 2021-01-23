    [Test]
    public void BreakTest()
    {
        for (int i = 0; i < 2; i++)
        {
            bool condition = i == 0;
            if(!condition)
                Debugger.Break();
            Assert.IsTrue(condition);
        }
    }
