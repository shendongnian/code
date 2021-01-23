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
    public class SomeState : StateBase
    {
        private SomeView my_view;
        public IView view
        {
            get { return (IView)SomeView; }
            set { ; }
        }
    }
    //program remains unchanged
