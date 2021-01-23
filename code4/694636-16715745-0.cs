    foreach (string address in addresses)
    {
        try
        {
            addressCollection.Add(address);
        }
        catch (EmailNotSentException ex)
        {
            if (IsCausedByMissingCcAddress(ex))
            {
                // Handle this case here e.g. display a warning or just nothing
            }
            else
            {
                throw;
            }
        }
    }
