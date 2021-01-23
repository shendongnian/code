    [TestMethod]
    public void GetNearestTest()
    {
        var data = new[] { 0, 9, 0, 0, 5, 0, 0, 8, 4, 1, 3, 0, 0, 0, 0 };
        var normalised = Program.GetNormalised(data);
    
        var value = 7;
        var expected = 4;
        var actual = Program_Accessor.GetNearest(normalised, value);
        Assert.AreEqual(expected, actual);
    
        value = 2;
        expected = 9;
        actual = Program_Accessor.GetNearest(normalised, value);
        Assert.AreEqual(expected, actual);
    
        value = 8;
        expected = 7;
        actual = Program_Accessor.GetNearest(normalised, value);
        Assert.AreEqual(expected, actual);
    
        value = 9;
        expected = 1;
        actual = Program_Accessor.GetNearest(normalised, value);
        Assert.AreEqual(expected, actual);        
    }
