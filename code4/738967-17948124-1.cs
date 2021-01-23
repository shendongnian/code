    [TestMethod]
    public void checkEnumVals()
    {
            var ts = TaskStatusTestEnum.Open;
            ts |= TaskStatusTestEnum.OnHold;
        
            bool matchBoth = false;
            if ((ts & TaskStatusTestEnum.OnHold) == TaskStatusTestEnum.OnHold && (ts & TaskStatusTestEnum.Open) == TaskStatusTestEnum.Open)
               matchBoth = true;
        
            Assert.IsTrue(matchBoth);
    }
