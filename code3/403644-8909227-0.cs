    try
    {
        // Do stuff
    }
    catch (SpecificException ex)
    {
        try
        {
            // Try e-mailing
        }
        catch (AnotherException ex1)
        {
            // Write local log file
        }
     }
