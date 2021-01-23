        try
        {
            // Execute some code
        }
        catch (HandledException e)
        {
            LogError(e.InnerException);
            // Do something else
        }
        catch (Exception e)
        {
            throw ;
        }
