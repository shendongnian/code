    public class A : ICloneable
    {
    	public int PropertyA { get; protected set; }
    	
    	public object Clone()
    	{
    		Console.WriteLine("Clone A called");
    		A copy = new A();
    		copy.PropertyA = this.PropertyA;
    		return copy;
    	}
    }
    
    public class B : A, ICloneable
    {
    	public int PropertyB { get; protected set; }
    	
    	public new object Clone()
    	{
    		Console.WriteLine("Clone B called");
    		B copy = new B();
    		copy.PropertyA = this.PropertyA;
    		copy.PropertyB = this.PropertyB;
    		return copy;
    	}
    }
