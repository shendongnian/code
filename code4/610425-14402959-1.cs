    public class StateCollection
        {
            private readonly List<IState<IView>> _states = new List<IState<IView>>();
    
            public void AddState(IState<IView> state)
            {
                _states.Add(state);
            }
        }
