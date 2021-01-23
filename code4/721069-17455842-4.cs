    private static bool _continueLoop = true;
    private static readonly object _continueLoopLock = new object();
    
    private static void StopLoop() 
    { 
        lock(_continueLoopLock) 
            _continueLoop = false;
    }
    
    private static void ThreadALoopWillGetStales()
    {
        while(_continueLoop)
        {
            //do stuff
            //this is not guaranteed to end
        }
    }
    
    private static void ThreadALoopEventuallyCorrect()
    {
        while(true)
        {
            bool doContinue;
            
            lock(_continueLoopLock)
                doContinue = _continueLoop;
            
            if(!doContinue)
                break;
            //do stuff
            //this will sometimes result in a stale value
            //but will eventually be correct
        }
    }
    private static void ThreadALoopAlwaysCorrect()
    {
        while(true)
        {
            bool doContinue;
            
            lock(_continueLoopLock)
               if(!_continueLoop)
                break;
            //do stuff
            //this will always be correct
        }
    }
    private static void ThreadALoopPossibleDeadlocked()
    {
         lock(_continueLoopLock)
             while(_continueLoop)
             {
                 //if you only modify "_continueLoop"
                 //after Acquiring "_continueLoopLock"
                 //this will cause a deadlock 
             }
    }
    
    private static void StartThreadALoop()
    {
        ThreadPool.QueueUserWorkItem ((o)=>{ThreadALoopWillGetStales();});
    }
    private static void StartEndTheLoop()
    {
        ThreadPool.QueueUserWorkItem((o)=>
        {
           //do stuff
           StopLoop();
        });
    }
    
    public static void Main(string[] args)
    {
        StartThreadALoop();
        StartEndTheLoop();
    }
    
