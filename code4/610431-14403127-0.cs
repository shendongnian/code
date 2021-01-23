    public class StateCollection
    {
    	private IList<IState<IView>> _states = new List<IState<IView>>();
    
    	public void AddState(IState<IView> state) // no longer generic 
    	{
    		_states.Add(state);
    	}
    }
    
    public class SomeState : IState<SomeView>
    {
    	public SomeView View
    	{
    		get; private set;
    	}
    }
    
    public class SomeView : IView
    {
    }
    
    public interface IState<out T> where T : IView // now covariant with T
    {
    	T View { get; }
    }
    
    public interface IView
    {
    }
