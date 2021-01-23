    static object lockObject = new Object();
    MyObject myObject = new MyObject (); 
     
    public void FunA () // accessed from thread 1 (when user click a button) 
    { 
        lock (lockObject)
        {
            myObject = null; 
            // do some stuff 
            myObject = new MyObject ( someNewValues ); 
        }
    } 
     
    public void FunB () // accessed from thread 2 (calling using timer or smth.) 
    { 
        lock (lockObject)
        {
            int x = myObject.ReadX (); 
        }
    } 
