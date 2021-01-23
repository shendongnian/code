    public interface IScrollableCursor
    {
        void MoveNext();
        void MovePrevious();
        void MoveFirst();
        void MoveLast();
        bool BOF();
        bool EOF();
        char Peek();
        int CurrentPosition { get; }
    }
    [Serializable]
    public abstract class AtomicState
    {
        protected int stateId;
        protected bool accepted;
        public int StateId
        {
            get
            {
                return stateId;
            }
        }
        public AtomicState( int stateId )
        {
            this.stateId = stateId;
            this.accepted = false;
        }
        public AtomicState( int stateId, bool accepted )
            : this( stateId )
        {
            this.accepted = accepted;
        }
        public abstract bool Initial { get; }
        public bool Accepted
        {
            get
            {
                return accepted;
            }
        }
    }
    [Serializable]
    public struct Actor : ICloneable
    {
        private AtomicState state;
        private IScrollableCursor cursor;
        public AtomicState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        public IScrollableCursor Cursor
        {
            get
            {
                return cursor;
            }
        }
        public Actor( AtomicState state, IScrollableCursor cursor )
        {
            this.state = state;
            this.cursor = cursor;
        }
        public object Clone()
        {
            return this.DeepClone();
        }
    }
	
	public class Transition
    {
        protected AtomicState fromState;
        protected Func<Char> input;
        protected bool epsilon;
        public AtomicState FromState
        {
            get
            {
                return fromState;
            }
        }
        public Func<Char> Input
        {
            get
            {
                return input;
            }
        }
        public bool Epsilon
        {
            get
            {
                return epsilon;
            }
        }
        public Transition( AtomicState fromState, Func<Char> input )
        {
            this.fromState = fromState;
            this.input = input;
        }
        public Transition( AtomicState fromState, bool epsilon )
            : this( fromState, null )
        {
            this.epsilon = epsilon;
        }
    }
    public class EpsilonTransition : Transition
    {
        public EpsilonTransition( AtomicState fromState )
            : base( fromState, true )
        {
        }
    }
	
	
	public eResult Execute()
	{
		var startState = States.FirstOrDefault( s => s.Initial );
		if ( startState == null ) return eResult.RejectedNoInitialState;
		tasks.Clear();
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
		eResult result = eResult.Accepted;
		if ( !results.Any() ) result = eResult.RejectedNoResults;
		else if ( results.Where( r => r.State.Accepted ).Count() > 1 ) result = eResult.RejectedAmbiguous;
		return result;
	}
