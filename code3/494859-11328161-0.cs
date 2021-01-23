    class Foo
    {
    	public string Text { get; set; }
    	public string Value { get; set; }
    	
    	public override bool Equals(object obj)
    	{
    		var foo = obj as Foo;
    		if(foo == null) return false;
    		
    		return foo.Text == Text && foo.Value == Value;
    	}
    	
    	public override int GetHashCode()
    	{
    		return Text.GetHashCode() * Value.GetHashCode() ^ 7;	
    	}
    }
