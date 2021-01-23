	CancellationTokenSource cts = new CancellationTokenSource();
	ExecutionDataflowBlockOptions options = new ExecutionDataflowBlockOptions();
	options.MaxDegreeOfParallelism = 4;
	options.CancellationToken = cts.Token;
	// transitions an actor onto it's next state
	TransformBlock<Tuple<Transition, Actor>, Actor> actorTransitioner = new TransformBlock<Tuple<Transition, Actor>, Actor>( tr =>
		{
			return doTransitionFunction( tr.Item1, cts ).Invoke( tr.Item2 );
		}, options );
	BroadcastBlock<Actor> actorTransitionerBroadcaster = new BroadcastBlock<Actor>( a => { return a; } );
	ActionBlock<Actor> actorProcessor = new ActionBlock<Actor>( a =>
		{
			foreach ( Transition t in getTransitions( a.State ) )
			{
				actorTransitioner.Post( new Tuple<Transition, Actor>( t, (Actor)a.Clone() ) );
			}
		} );
	// link blocks
	actorTransitioner.LinkTo( actorTransitionerBroadcaster );
	actorTransitionerBroadcaster.LinkTo( actorProcessor );
	actorTransitionerBroadcaster.Post( new Actor( startState, input ) );
	try
	{
		actorTransitioner.Completion.Wait();
	}
	catch ( AggregateException ex )
	{
		foreach ( Exception ae in ex.Flatten().InnerExceptions )
		{
			Console.WriteLine( ae.Message );
		}
	}
