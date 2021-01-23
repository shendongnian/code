    public abstract class A
    {
    	abstract void DoSomething();
    }
    
    void Iterate()
    {
    	Foo f = new Foo();
    	foreach(A item in f.Collection)
    	{
    		item.DoSomething();
    	}
    }
