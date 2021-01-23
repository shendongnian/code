    public class HookObj<T> : HookObj
    {
    	public Action<T> setMethod { get; private set; }
    	public Func<T> getMethod { get; private set; }
    
    	public HookObj(Action<T> setMethod, Func<T> getMethod)
    		: base(typeof(T))
    	{
    		this.setMethod = setMethod;
    		this.getMethod = getMethod;
    	}
    	
    	public override void SetValue(object value)
    	{
    		setMethod((T)value);
    	}
    	
    	public override object GetValue()
    	{
    		return getMethod();
    	}
    }
    
    
    public abstract class HookObj
    {
    	public Type theType { get; private set; }
    
    	public HookObj(Type theType)
    	{
    		this.theType = theType;
    	}
    	
    	public abstract void SetValue(object value);
    	public abstract object GetValue();
    }
