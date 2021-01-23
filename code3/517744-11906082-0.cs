    while (ProcessValues(...))
    {
        // Body left deliberately empty
    }
    ...
    private bool ProcessValues()
    {
       for (int i = 0; i < 15; i++)
       {
           // Do something
           return false;
       }
       return true;
    }
