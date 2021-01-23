    public absract class StateBase
    {
        public IView view { get; set; }
        ....
    }
    public Interface IView
    { ... }
    public class StateCollection
    {
        private List<StateBase> _states = new List<StateBase>();
        public void AddState(StateBase state)
        {
            _states.Add(state);
        }
    }
    public class SomeView : IView
    { ... }
