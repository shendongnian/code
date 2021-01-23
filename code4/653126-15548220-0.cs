    class MyClass
    {
    	public string FName { get; set; }
    	public string BabatMah { get; set; }
    	
    	public int x { get; set; }
    	public int y { get; set; }
    	
    	public int z { get { return x - y; }	}
    	public int karkard { get; set; }
        // implement Equals and GetHashCode for correct behaviour of Distinct
    }
