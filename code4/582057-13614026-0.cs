    void Main() {
    	var f = new Foo();
    	
    	Console.WriteLine (f.S1);
    	Console.WriteLine (f.S1.HasValue);
    }
    
    class Foo {
    	private double? _s1 = null;
    
    	public double? S1 {
    		get { return _s1; }
    		set { _s1 = value; }
    	}	
    }
