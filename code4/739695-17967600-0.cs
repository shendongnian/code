    try
    {
        // ...
        Assert.Fail("message");
        // ...
    }
    catch (Exception ex)
    {
        if (ex is AssertFailedException)
        {
            throw;
        }
    }
