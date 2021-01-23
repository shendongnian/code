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
    
    	public static MyClassDelegate Create<TMember>(Expression<Func<MyClass, TMember>> expressionLambda)
    	{
    		var stronglyTypedFunction = expressionLambda.Compile();
    		Func<MyClass, object> nonTypedFunction = o => stronglyTypedFunction(o);
    		return new MyClassDelegate(nonTypedFunction, expressionLambda.ReturnType);
    	}
    }
