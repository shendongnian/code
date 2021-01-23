    catch (Exception e)
    {
        // As Reed pointed out, you can move this into the if block if you want
        // different messages for the two cases.
        Console.WriteLine("Caught exception {0}", e.Message);
        TimeoutException timeoutException = e as TimeoutException;
        if (timeoutException != null)
        {
            // Do stuff with timeout info...
        }
        else
        {
            // Not a timeout error, fail immediately
            return false;
        }
    }
