    bool triggered;
    EventHandler handler = (s, e) => triggered = true;
    CommandManager.RequerySuggested += handler;
    CommandManager.InvalidateRequerySuggested();
    // Ensure the invalidate is processed
    Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new Action(() => { }));
    GC.KeepAlive(handler);
    Assert.IsTrue(triggered);
