    public class Class1
    {
    	private class Class2
    	{
    		public void Add(int a, int b) // Method in Class 2
    		{
    			this.Add(a, b);
    		}
    	}
    
    	public Class1() // constructor of Class 1
    	{
    		Class2 newclass2 = new Class2();
    		newclass2.Add(1, 2);
    		// Get this Add method by This.Add ??
    		// Not able to fetch the Add method here.
    	}
    }
