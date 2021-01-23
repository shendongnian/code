    public MyClass(object someValue)
    {
        Dispatcher.BeginInvoke(
            (Action)(() => Property = someValue),  // the cast may not be required
            DispatcherPriority.ApplicationIdle);  // runs after everything is loaded
    }
