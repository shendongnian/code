    var parameterName =
        typeof(Foo)
	    .GetConstructor(new[] { typeof(string) })
	    .GetParameters()
	    .Single().Name;
    
    public class Foo
    {
        public Foo(string paramName)
        {	
        }
    }
