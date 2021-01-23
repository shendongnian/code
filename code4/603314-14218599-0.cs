    int _TimerLock = 0;
	void TimerTickSafe( object state )
	{
		if ( Interlocked.CompareExchange( ref _TimerLock, 1, 0 ) != 0 ) return;
		try
		{
			TimerTick();
		}
		finally
		{
			Interlocked.Exchange( ref _TimerLock, 0 );
		}
	}
