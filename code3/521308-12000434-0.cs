    foreach (string pattern in patternArray)
    {
        try
        {
            foreach (string path in Directory.GetFiles(...))
            {
                // ...
            }
        }
        catch (IOException e)
        {
            // Log it or whatever
        }
        // Any other exceptions you want to catch?
    }
