    public static void DoSomething()
    {
        bool success = true;
        try
        {
            //some code
            try
            {
                //some other code
            } catch (Exception ex)
            {
                success = false;
                try
                {
                    //some other code
                } catch (ExceptionA eA)
                {
                    log.Error("At the end, something went wrong: " + eA);
                } catch (ExceptionB eB)
                {
                    log.Error("At the end, something else went wrong: " + eB);
                }
            }
        } catch (Exception ex)
        {
            success = false;
            log.Error("At the start something wrong: " + ex);
        }
        if(!success)
            FunctionA();
    }
