    try
    {
        fileStream.Read(...);  // or some other operation
    }
    catch(Exception e)
    {
        AlertUserWithMessageAndStackTrace(e.Message, e.StackTrace);
    }
