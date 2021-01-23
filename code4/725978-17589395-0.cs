    try
    {
        CodeThatThrowsExceptions();
    }
    catch(ArgumentException ae)
    {
        //Recoverable, request new args
    }
    catch(OtherRecoverableException oe)
    {
        //take appropriate action
    }
    catch(Exception e)
    {
        //Unexpected irrecoverable error. Handle appropriately
    }
