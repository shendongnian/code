    private void timerCallBackMethod(object state)
    {
         if(myThread.ThreadState == System.Threading.ThreadState.Stopped || myThread.ThreadState == System.Threading.ThreadState.Unstarted)
         {
            //dispatch new thread
         }
    }
