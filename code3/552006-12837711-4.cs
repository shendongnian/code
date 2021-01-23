    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public async Task DivideTest1()
    {
      int Result = await AsyncMathsStatic.Divide(4, 0);
    }
