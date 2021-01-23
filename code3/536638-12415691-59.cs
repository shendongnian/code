	var synchronizationContext = TaskScheduler.FromCurrentSynchronizationContext();
	Task.Factory.StartNew(() =>
	                      {
	                      	int i = 0;
	                      	// simulate lengthy operation
	                      	Stopwatch sw = Stopwatch.StartNew();
	                      	while (sw.Elapsed.TotalSeconds < 1)
	                      		++i;
	                      }).ContinueWith(t=>
	                                      {
	                                      	// TODO: do something on the UI thread, like
	                                      	// update status or display "result"
	                                      }, synchronizationContext);
