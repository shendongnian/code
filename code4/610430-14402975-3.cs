    public class StateCollection
    {
        private List<IState<IView>> _states = new List<IState<IView>>();
        public void AddState(IState<IView> state)
        {
            _states.Add(state);
        }
    }
    public class SomeState : StateBase<SomeView>
    {
        public override SomeView View
        {
            get { return null; }
        }
    }
    public abstract class StateBase<T> : IState<T> where T : IView
    {
       public abstract T View { get; }
    }
    public interface IState<out T> where T : IView
    {
        T View { get; }
    }
