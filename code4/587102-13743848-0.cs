    class IgnoreWhitespaceStringComparer : IEqualityComparer<string>
    {
    	public new bool Equals(string x, string y)
    	{
    		return x.Trim().Equals(y.Trim());
    	}
    
    	public int GetHashCode(string obj)
    	{
    		return obj.Trim().GetHashCode();
    	}
    }
