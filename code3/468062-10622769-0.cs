    public class Data
    {
    	private object UnderlyingValue;
    	
    	private Data(object underlyingValue)
    	{
    		this.UnderlyingValue = underlyingValue;
    	}
    	
    	public static implicit operator Data(string value)
    	{
    		return new Data(value);
    	}
    	
    	public static implicit operator Data(bool value)
    	{
    		return new Data(value);
    	}
    }
    var data = new Data[] { 1, "string", true }; //compiler error on "1" because no supporting conversion method is provided
