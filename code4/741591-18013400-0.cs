    void Main()
    {
    	object o1 = new M { A = 1 };
    	object o2 = o1;
    	
    	// o2.A = 100 (this can also be done using dynamic)
    	var prop = typeof(M).GetProperty("A");
    	prop.SetValue(o2, 100);
    	
    	// prints 100, since both point to the same instance
    	Console.WriteLine(((M)o1).A);
    }
    
    public struct M {
    	public int A { get; set; }
    }
