    private static AutoResetEvent resetEvent = new AutoResetEvent(false); 
    static void WaitForOpenSpot()
    {  
        resetEvent.WaitOne();
    }
    static void ChangeStatus(string str, int val)
    {
       Transfer[str] = val;
       if (val == 1)
       {
           resetEvent.Set();
       }
    }
