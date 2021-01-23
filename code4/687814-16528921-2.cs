    try
    {
        methodToThrowException();
        Assert.Fail("BusinessSpecificException was not thrown by the code.");
    }
    catch (BusinessSpecificException ex)
    {
        //Asserts go here
    }
