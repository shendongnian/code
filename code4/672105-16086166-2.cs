    public abstract class MyClass
    {
        public string Value1 { get; set; }
        public abstract object Value2Untyped { get; set; }
        public string Value3 { get; set; }
    }
    public class MyClass<T> : MyClass
    {
    	public T Value2 { get; set; }
    	public override object Value2Untyped
    	{
    		get
    		{
    			return Value2;
    		}
    		set
    		{
    			Value2 = (T)value;
    		}
    	}
    }
