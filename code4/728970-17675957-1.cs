    class Foo
    {
    	public void Method() 
    	{
    		Console.WriteLine(this == null);
    	}
    }
    
    Action<Foo> action = (Action<Foo>)Delegate.CreateDelegate(typeof(Action<Foo>), null, typeof(Foo).GetMethod("Method"));
    action(null); //prints True
