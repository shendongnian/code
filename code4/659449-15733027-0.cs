    Task DoAllWork( IEnumerable<WorkItem> workItems )
    {
	  int THREAD_COUNT = 4;
	
	  var bag = new ConcurrentBag<WorkItem>( workItems );
	  var ce = new CountdownEvent( THREAD_COUNT );
	  var tcs = new TaskCompletionSource<bool>();
	
	  for ( int i = 0 ; i < THREAD_COUNT ; i++ ) Work( bag, ce, tcs );
	
	  return tcs.Task;
    }
	void Work(
	  ConcurrentBag<WorkItem> bag,
	  CountdownEvent ce,
	  TaskCompletionSource<bool> tcs
	)
	{
		WorkItem workItem;
		if ( bag.TryTake( out workItem) )
		{
			WrapExternalProcess( workItem )
			  .ContinueWith( t => Work( bag, ce, tcs ) );
		}
		else // no more work
		{
            // If I'm the last thread to finish
			if ( ce.Signal() ) tcs.SetResult( true );
		}
	}
