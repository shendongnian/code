    private void MyMethod()
    {
        if(condition1)
        {
            // do something
        
            if (counter==1)
            { 
                MyOtherMethod();
            }        
        }    
        else if (condition2)
        { 
            if (counter == 2)
            { 
                MyOtherMethod();
            }
            else
            {
                // do something
            }
        }
        else
        {
            MyOtherMethod()
        }
    }
    
    private void MyOtherMethod()
    {
        // Do what was in your final else clause.
    }
