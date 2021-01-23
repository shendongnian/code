    public class SetOnce<T> where T : class
    {
    	private static readonly Func<T> NoValueSetError = () => { throw new System.Exception("Value not yet present.");};
    	
    	private Func<T> ValueGetter = NoValueSetError;
    	private readonly object SetterLock = new object();
    	
    	public T SetValue(T newValue)
    	{
    		if (newValue == null)
    			throw new ArgumentNullException("newValue");
    	
    		lock (SetterLock)
    		{
    			if (ValueGetter != NoValueSetError)
    				throw new System.Exception("Value already present.");
    			else
    				ValueGetter = () => newValue;
    		}
    		
    		return newValue;
    	}
    	
    	public T GetValue()
    	{
    		return ValueGetter();
    	}
    }
