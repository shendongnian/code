    public class CustomHook<T> : HookObj<T>
    {
    	public Func<string, T> inputParser { get; private set; }
    	
    	public CustomHook(Func<string, T> parser)
    	{
    		if (parser == null)
    			throw new ArgumentNullException("parser");
    			
    		this.inputParser = parser;
    	}
    	
    	protected override T Parse(string value)
    	{
    		return inputParser(value);
    	}
    }
