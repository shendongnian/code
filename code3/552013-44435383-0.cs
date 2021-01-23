    [TestMethod]
    public void DivideTest1()
    {
        Func<Task> action = async () => { int Result = await AsyncMathsStatic.Divide(4, 0); });
        action.ShouldThrow<DivideByZeroException>();
    }
