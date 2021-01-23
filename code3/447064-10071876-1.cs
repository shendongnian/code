    private long _shouldRun;
    private bool shouldRun
    {
        get 
        { 
            var l = Interlocked.Read( ref _shouldRun );
            return l != 0;
        }
        set
        {
            Interlocked.Exchange( ref _shouldRun, value ? 1 : 0 );
        }
    }
