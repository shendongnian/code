    void DoEvents()
    { 
        DispatcherFrame f = new DispatcherFrame(); 
        Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate(object arg) 
                  { 
                  DispatcherFrame fr =  arg as DispatcherFrame; 
                  fr.Continue=True; 
                  }, f); 
        Dispatcher.PushFrame(frame); 
    }
