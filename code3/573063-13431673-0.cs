    public eResult Execute()
    {
        var startState = States.FirstOrDefault( s => s.Initial );
        if ( startState == null ) return eResult.RejectedNoInitialState;
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;
        Task t = new Task( () =>
            {
                Parallel.ForEach( getTransitions( startState ), new ParallelOptions { MaxDegreeOfParallelism = 4 }, tr =>
                {
                    var a0 = new Actor( tr.FromState, (IScrollableCursor)this.input.DeepClone() );
                    var a1 = doTransitionFunction( tr, cts ).Invoke( a0 );
                    if ( a0.State != a1.State )
                        processRecursively( a1.State, a0, cts );
                } );
            }, cts.Token );
        t.RunSynchronously();
        eResult result = eResult.Accepted;
        if ( !results.Any() ) result = eResult.RejectedNoResults;
        else if ( results.Where( r => r.State.Accepted ).Count() > 1 ) result = eResult.RejectedAmbiguous;
        return result;
    }
    void processRecursively( AtomicState s, Actor a0, CancellationTokenSource cts )
    {
        Parallel.ForEach( getTransitions( s ), tr =>
            {
                var a1 = doTransitionFunction( tr, cts ).Invoke( a0 );
                if ( a0.State != a1.State )
                    processRecursively( a1.State, a1, cts );
            } );
    }
