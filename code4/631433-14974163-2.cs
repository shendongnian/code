    // This is a good practice
    try
    {
        ...
    }
    catch(Exception ex)
    {
        throw new ApplicationException("Something wrong happened in the calculation module :", ex);
    }
