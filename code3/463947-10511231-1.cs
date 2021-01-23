    private IDisposable _subscription;
    
    public EventDispatcher(IChannelListener listener)
    {
        TimeEventChannel = _TimeSubject;
        SpaceEventChannel = _SpaceSubject;
        _subscription = listener.Data.Subscribe(SwitchEvent);
    }
