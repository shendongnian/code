    var myObject = new MyObject();
    
    try
    {
        myObject.MethodUnderTest();
    }
    catch (Exception ex)
    {
        Assert.Fail("Expected no exception, but got: " + ex.Message);
    }
