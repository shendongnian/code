    // Calculation module
    try
    {
        ...
    }
    catch(Exception ex)
    {
        // Add useful information to the exception
        throw new ApplicationException("Something wrong happened in the calculation module :", ex);
    }
    // IO module
    try
    {
        ...
    }
    catch(Exception ex)
    {
        throw new ApplicationException(string.Format("I cannot write the file {0} to {1}", fileName, directoryName), ex);
    }
