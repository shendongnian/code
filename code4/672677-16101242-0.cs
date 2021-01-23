    bool success = false;
    try
    {
        ...
        // This should be the last statement in the try block
        success = true;
    }
    catch(...)
    {
        ...
    }
    finally
    {
        if (success)
        {
            ...
        }
    }
