    public void lotsOfAsync()      
    {
        Int32 numberOfAsyncProcesses = Async1List.Length + 1;         
        CountdownEvent countdown = new CountdownEvent (numberOfAsyncProcesses);
        
        DoAsync1(countdown); // call set in the async method once complete.
             
        for each ( MyClass in Async1List)           
        { 
            // call set in the async method once complete.
            MyClass.DoAsyn2(countdown);        
        }   
              
        if(countDown.Wait(TimeSpan.FromSeconds(3))
        {             
            FinalAction();      
        }
    }
