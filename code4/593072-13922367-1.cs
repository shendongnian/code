    bool example()
    {
        // Attempt the operation a maximum of three times.
        for (int i = 0; i < 3; i++)
        {
            try
            {
                work();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception {0}", e.Message);
                // Fail immediately if this isn't a TimeoutException.
                if (!(e is TimeoutException))
                    return false;
            }
        }
        return false;
    }
