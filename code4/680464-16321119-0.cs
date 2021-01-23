    public class OverridableValue<T>
    {
    	private readonly Func<T> OriginalValueGetter;
    	private Func<T> ValueGetter;
    	
    	public OverridableValue(Func<T> valueGetter)
    	{
    		this.OriginalValueGetter = valueGetter;
    		this.ValueGetter = OriginalValueGetter;
    	}
    	
    	public T Value
    	{
    		get 
    		{
    			return ValueGetter();
    		}
    	}
    	
    	public void SetValueOverride(T value)
    	{
    		if (value == null)
    			ValueGetter = OriginalValueGetter;
    		else
    			ValueGetter = () => value;
    	}
    }
