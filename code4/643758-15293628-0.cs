    public void StartThread()
    {
       Thread th = new Thread(function);
       th.IsBackground = true;
       th.start();
    }
    
    public void function()
    {    
       //preferably have some way of killing this if needs be so don't necessarily use 'true'
       while(true)
       {
          //do stuff
    
          //sleep an appropriate amount of time to not overload the cpu
          //This sleeps (basically pauses thread) for 10 milliseconds
          Thread.Sleep(10);
       }
    }
