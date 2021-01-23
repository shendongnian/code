    class MyClass
    {
    	public string Value {get; private set;}
    	public MyClass(string s)
    	{
    		this.Value = s;
    	}
    	public static implicit operator MyClass(string s)
    	{
    		return new MyClass(s);
    	}
    }
