    private void ThreadingTimerTick(object state)// or wahterver your method is.
    {
       Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate()
       {
         // do stuff
       });
    }
