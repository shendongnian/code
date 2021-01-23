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
            } catch (Exception e2)
            {
                log.Error("At the end something is wrong: " + e);
            } catch (Exception e3)
            {
                log.Error("At the start something wrong: " + e);
            }
            FunctionA();
        }
    }
