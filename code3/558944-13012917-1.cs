    var are = new AutoResetEvent(true);
    sender.Dispatcher.Invoke(DispatcherPriority.Normal,                                      
            new Action(async () =>
            {
               try { ... } catch { ... } finally { are.Set(); }
            }));
 
    are.WaitOne();
    return result;
