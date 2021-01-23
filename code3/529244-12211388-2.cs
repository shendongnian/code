    public static void DoSomething()
    {
        try
        {
            //some code
        }
        catch(Exception ex){
            FunctionA();
            log.Error("At the start something wrong: " + e);
            try
            {
                //some other code
            } catch (ExceptionA eA)
            {
                log.Error("At the end something is wrong: " + e);
            } catch (ExceptionB eB)
            {
                log.Error("At the end something other wrong: " + e);
            }
        }
    }
