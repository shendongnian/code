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
                    log.Error("At the end, something went wrong: " + e);
                } catch (ExceptionB eB)
                {
                    log.Error("At the end, something else went wrong: " + e);
                }
            }
        } catch (Exception ex)
        {
            success = false;
            log.Error("At the start something wrong: " + e);
        }
        if(!success)
            FunctionA();
    }
