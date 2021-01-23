    static void main(string[] args)
    {
    #if(DEBUG)
        try
        {
            MainMethodBody(args);
        }
        catch(Exception ex)
        {
            // log ex.ToString() here
            // Do not rethrow! Let it die.
        }
    #else
        MainMethodBody(args);
    #endif
    }
    
    static void MainMethodBody(string[] args)
    {
        //Your entry point's code goes here
    }
