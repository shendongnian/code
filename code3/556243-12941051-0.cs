    public void ClosureOverVariable()
    {
    	var a = "x";
    
    	Func<string> d = () => a;
    
    	Console.WriteLine(d()); // print "x"
    
    	a = "y";
    
    	Console.WriteLine(d()); // print "y"
    }
    
    class Foo
    {
    	public string X { get; set; }
    }
    
    public void ClosureOverProperty()
    {
    	var a = new Foo
    		{
    			X = "a"
    		};
    
    	Func<string> d = () => a.X;
    
    	Console.WriteLine(d()); // prints "a"
    
    	a.X = "y";
    
    	Console.WriteLine(d()); // print "y"
    }
