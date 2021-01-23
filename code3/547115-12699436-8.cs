    public abstract class HookObj<T> : HookObj
    {
    	public Action<T> setMethod { get; private set; }
    	public Func<T> getMethod { get; private set; }
    	
    
    	protected HookObj()
    		: base(typeof(T))
    	{
    		
    	}
    	
    	public void SetSetter(Action<T> setMethod)
    	{
    		this.setMethod = setMethod;
    	}
    	
    	public void SetGetter(Func<T> getMethod)
    	{
    		this.getMethod = getMethod;
    	}
    	
    	protected abstract T Parse(string value);
    	
    	public override void SetValue(string value)
    	{
    		T parsedValue = Parse(value);
    		setMethod(parsedValue);
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
    	
    	public abstract void SetValue(string value);
    	public abstract object GetValue();
    }
