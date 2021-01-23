    void Main()
    {
    	var p = Expression.Parameter(typeof(int), "presenter");
    	var instance = Expression.Variable(typeof(Foo), "instance");
    	var ctor = typeof(Foo).GetConstructor(new Type[0]);
    	var block = Expression.Block(new [] { instance },
    		Expression.Assign(instance, Expression.New(ctor)),
    		Expression.Assign(Expression.Property(instance, "SomeProperty"), p),
    		instance
    	);
    	
    	var lambda = Expression.Lambda<Func<int,Foo>>(block, p);
    	Foo f = lambda.Compile()(5);
        Console.WriteLine(f.SomeProperty);
    }
    
    class Foo 
    {
    	public int SomeProperty {get;set;}
    }
