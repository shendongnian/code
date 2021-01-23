    public abstract class Response
    {
    	public object Value { get; set; }
    }
    
    public class Response<T> : Response
    {
    	private T _value;
    	public new T Value
    	{
    		get { return _value; }
    		set { base.Value = _value = value; }
    	}
    }
