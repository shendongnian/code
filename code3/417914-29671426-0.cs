    void MyMethod1()
    {
        try
        {
            MyMethod2();
            MyMethod3();
        }
        catch(Exception e)
        {
            //do something with the exception
        }
    }
    
    
    void MyMethod2()
    {
        try
        {
            //perform actions that need cleaning up
        }
        finally
        {
            //clean up
        }
    }
    
    
    void MyMethod3()
    {
        //do something
    }
