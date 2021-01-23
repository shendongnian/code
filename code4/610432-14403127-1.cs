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
    }
    
    public class SomeView : IView
    {
    }
    
    public interface IState<out T> where T : IView // now covariant with T
    {
    	T View { get; }
    }
    
    public abstract class StateBase<T> : IState<T> where T : IView
    {
    	public T View { get; set; }
    }
    
    public interface IView
    {
    }
