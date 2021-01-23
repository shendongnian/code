    try
    {
        try
        {
            ...
        }
        catch (Advantage.Data.Provider.AdsException)
        {
            if (...)
            {
                throw; // Throws to the *containing* catch block
            }
        }
    }
    catch (Exception e)
    {
        ...
    }
