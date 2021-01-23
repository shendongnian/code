    private void ThreadingTimerTick(object state)// or whatever your method is.
    {
       Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate()
       {
         // do stuff
       });
    }
