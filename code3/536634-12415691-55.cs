         var progress = new Progress<int>();
         progress.ProgressChanged += ( s, e ) =>
            {
               // TODO: do something with e.ProgressPercentage
               // like update progress bar
            };
         await Task.Factory.StartNew(() =>
                      {
                      	int i = 0;
                      	// simulate lengthy operation
                      	Stopwatch sw = Stopwatch.StartNew();
                      	while (sw.Elapsed.TotalSeconds < 1)
                      	{
                      		if ((sw.Elapsed.TotalMilliseconds%100) == 0)
                      		{
                      			progress.OnReport((int) (1000 / sw.ElapsedMilliseconds))
                      		}
                      		++i;
                      	}
                      });
	// TODO: do something on the UI thread, like
	// update status or display "result"
