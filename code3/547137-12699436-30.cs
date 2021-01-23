    public class StringHook : HookObj<string>
    {
    	protected override string Parse(string value)
    	{
    		return value;
    	}
    }
    
    public class IntHook : HookObj<int>
    {
    	protected override int Parse(string value)
    	{
    		return Int32.Parse(value);
    	}
    }
    
    public class FloatHook : HookObj<float>
    {
    	protected override float Parse(string value)
    	{
    		return float.Parse(value);
    	}
    }
