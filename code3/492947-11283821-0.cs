    try
    {
        fileStream.Read(...);  // or some other operation
    }
    catch(Exception e)
    {
        AlertUserWithMessage(e.Message);
    }
