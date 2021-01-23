    //casting someState may help also
    coll.AddState((IState<IView>)state);
    public class StateCollection
    {
        private List<IState<IView>> _states = new List<IState<IView>>();
        public void AddState(IState<IView> state)
        {
            _states.Add(state);
        }
    }
