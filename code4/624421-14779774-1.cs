    private int[] input = new int[] { 2, 8, 6, 1, 5, 1, 7, 5, 2, 4 };
    [TestMethod]
    public void TestVariantA() 
    {
        var obj = new ConcreteA();
        DoTest(obj, input, new int[] { -2.8, 3, 1.4, -3.2, 1 });
    }
    
    
    [TestMethod]
    public void TestVariantB() 
    {
        var obj = new ConcreteB();
        DoTest(obj, input, new int[] { 0.2632, 1.7500, 1.3397, 0.2381, 1.2500 });
    }
    
    private void DoTest(AbstractType obj, int input, int expected)
    {
        ...
    }
