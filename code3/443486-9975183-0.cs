    [Test]
    public void DoSomething_NullParameterEntered_ShouldCatchException()
    {
        var component = new Whatever();
    
        try
        {
            component.DoSomething(null);  //If a try/catch block exists it will not fall into the below catch
        }
        catch
        {
            Assert.Fail();
        }
    }
