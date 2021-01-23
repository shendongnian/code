    using AsyncAssert = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.AppContainer.Assert;
    [TestMethod]
    public void DivideTest1()
    {
        AsyncAssert.ThrowsException<DivideByZeroException>(async () => { 
            int Result = await AsyncMathsStatic.Divide(4, 0); });
    }
