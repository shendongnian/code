    public class myClass
    {
    	public int A { get; set; }
    	public int B { get; set; }
    	public int C { get; set; }
    	public int D { get; set; }
    
    	public bool Equals(myClass other)
    	{
    		if (ReferenceEquals(null, other)) return false;
    		if (ReferenceEquals(this, other)) return true;
    		return other.A == A && other.B == B && other.C == C && other.D == D;
    	}
    
    	public override bool Equals(object obj)
    	{
    		if (ReferenceEquals(null, obj)) return false;
    		if (ReferenceEquals(this, obj)) return true;
    		if (obj.GetType() != typeof (myClass)) return false;
    		return Equals((myClass) obj);
    	}
    
    	public override int GetHashCode()
    	{
    		unchecked
    		{
    			int result = A;
    			result = (result*397) ^ B;
    			result = (result*397) ^ C;
    			result = (result*397) ^ D;
    			return result;
    		}
    	}
    }
