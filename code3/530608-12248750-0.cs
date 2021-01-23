    try
    {
       await obj.GetIntAsync();
       Assert.IsTrue(false);
    }
    catch (NotImplementedException e)
    {
       Assert.IsTrue(true);
       Assert.Equal("Exception Message Text", e.Message);
    }
