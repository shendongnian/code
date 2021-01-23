    public IObservable<IBaseFrame> CreateHardwareObservable()
    {
        // The event source.
        // Or you might not need this if your class is static and exposes
        // the event as a static event.
        var source = new BaseFrameMonitor();
        
        // Create the observable.  It's going to be hot
        // as the events are hot.
        IObservable<EventPattern<BaseFrameEventArgs>> observable = Observable.
            FromEventPattern<BaseFrameEventArgs>(
                h => source.HardwareEvent += h,
                h => source.HardwareEvent -= h);
    
        // Return the observable, but projected.
        return observable.Select(i => i.EventArgs.BaseFrame);
    }
