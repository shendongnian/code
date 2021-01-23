    class Foo
    {
    	public int SomeVar;
    	public Foo( int i )
    	{
    		SomeVar = i;
    	}
    
    	public static implicit operator bool( Foo f )
    	{
    		return f.SomeVar != 0;
    	}
    }
    static void Main()
    {
        var f = new Foo(1);			
        if( f )
        {
        	Console.Write( "It worked!" );
        }
    }
