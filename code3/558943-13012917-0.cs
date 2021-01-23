    var are = new AutoResetEvent(false);
    sender.Dispatcher.Invoke(DispatcherPriority.Normal,                                      
            new Action(async () =>
            {
               try { ... } catch { ... } finally { are.Set(); }
            }));
 
    are.WaitOne();
    return result;
