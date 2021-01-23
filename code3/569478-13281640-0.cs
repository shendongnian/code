    try
    {
        ...
        //Do work as per normal
        ...
        form1.UpdateStatusBar("some new status");
    }
    catch (Exception)
    {
        //Any exception handling/logging you may need.
    }
    finally
    {
        //Indicate that we are done.
        resetEvent.Set();
    }
