    var cts = new CancellationTokenSource( 5000 );  // auto-cancel in 5 sec.
    Task.Run( () => {
        cts.Token.ThrowIfCancellationRequested();
        // do background work
        
        cts.Token.ThrowIfCancellationRequested();
        // more work
           
    }, cts.Token ).ContinueWith( task => {
        if ( !task.IsCanceled && task.IsFaulted )   // suppress cancel exception
            Logger.Log( task.Exception );           // log others
    } );
