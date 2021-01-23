    public class MyClassDelegate
    {
    	private readonly Func<MyClass, object> Function;
    	
    	public Type ReturnType { get; private set; }
    	
    	private MyClassDelegate(Func<MyClass, object> function, Type returnType)
    	{
    		this.Function = function;
    		this.ReturnType = returnType;
    	}
    	
    	public object Invoke(MyClass context)
    	{
    		return Function(context);
    	}
    
    	public static MyClassDelegate Create<TReturnType>(Func<MyClass, TReturnType> function)
    	{
    		Func<MyClass, object> nonTypedFunction = o => function(o);
    		return new MyClassDelegate(nonTypedFunction, typeof(TReturnType));
    	}
    }
