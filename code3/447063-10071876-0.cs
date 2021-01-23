    private long _lastTriggeredTicks;
    private DateTime lastTriggered
    {
        get 
        { 
            var l = Interlocked.Read( ref _lastTriggeredTicks );
            return new DateTime( l );
        }
        set
        {
            Interlocked.Exchange( ref _lastTriggeredTicks, value );
        }
    }
