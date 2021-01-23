    public TestObject GetTestObject()
    {
        return this.myTestObject.Value;
    }
    
    public AnotherTestObject GetAnotherTestObject()
    {
        var testObject = this.myTestObject.Value; // re-used
    
        Logic myLogic = new MyLogic();
        return myLogic.GetAnotherTestObject(testObject);
    }
