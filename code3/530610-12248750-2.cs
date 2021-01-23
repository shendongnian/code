    try
    {
       await obj.GetIntAsync();
       Assert.Fail("No exception was thrown");
    }
    catch (NotImplementedException e)
    {      
       Assert.Equal("Exception Message Text", e.Message);
    }
