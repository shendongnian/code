    int requests = 0;
    void CheckAll ()
    {
     lock(SyncRoot){
        if (checkThread != null; && checkThread.IsRunning)
        {  
            requests++;
            return;
        }else
        {
            CheckAllImpl();
        }
     }
    }
    void CheckAppImpl()
    {
     // start a new thread and run the following code in it.
     
     while (true)
     {
     // 1. Do what ever checkall need to do.
     // 2.
         lock (SyncRoot)
         {
             requests--;
             if  (!(requests > 0))
                break;
         }
     }
    }
