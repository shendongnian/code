    public static void DoSomething()
    {
        try
        {
            //some code
        }
        catch(Exception ex){
            try
            {
                //some other code
            } catch (ExceptionA eA)
            {
                log.Error("At the end something is wrong: " + e);
            } catch (ExceptionB eB)
            {
                log.Error("At the start something wrong: " + e);
            }
            FunctionA();
        }
    }
