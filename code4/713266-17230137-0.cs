    public abstract class StateMachine
    {
        public StateMachine(params States[] allowedStates)
        {
            _allowedStates = allowedStates;
        }
        private readonly IEnumerable<States> _allowedStates;
        public IEnumerable<States> AllowedStates
        {
            get { return _allowedStates; }
        }
    }
    public class DerivedStateMachine : StateMachine
    {
        public DerivedStateMachine()
            : base(States.State1, States.State2)
        {
        }
    }
