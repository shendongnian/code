    private static void CallHandler(object sender, EventHandler eventHandler)
    {
        DispatcherProxy dispatcher = DispatcherProxy.CreateDispatcher();
        if (eventHandler != null)
        {
            if (dispatcher != null && !dispatcher.CheckAccess())
            {
                dispatcher.BeginInvoke((Action<object, EventHandler>)CallHandler, sender, eventHandler);
            }
            else
            {
                eventHandler(sender, EventArgs.Empty);
            }
        }
    }
