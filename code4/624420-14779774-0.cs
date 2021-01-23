    [TestMethod]
    public void TestVariantA() 
    {
        var obj = new ConcreteA();
        DoTest(obj);
    }
    
    
    [TestMethod]
    public void TestVariantB() 
    {
        var obj = new ConcreteB();
        DoTest(obj);
    }
    
    private void DoTest(AbstractType obj)
    {
        ...
    }
