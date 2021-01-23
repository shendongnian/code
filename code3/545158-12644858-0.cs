    public static volatile bool stop;    
    stop=False;
    
    DialCalls(x)
    {
      for(int i= 0 ; i<x && !stop ; i++)
      {
        // Initiate call
      }
    }
    
    On Button Click => stop =True;
