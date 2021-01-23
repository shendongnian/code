    static class AssertResemblance
    {
    	public static void Like<T, T2>( T expected, T2 actual )
    	{
    		Like( expected, actual, x => x );
    	}
    
    	public static void Like<T, T2>( T expected, T2 actual, Func<Likeness<T, T2>, Likeness<T, T2>> configureLikeness )
    	{
    		var likeness = expected.AsSource().OfLikeness<T2>();
    		configureLikeness( likeness ).ShouldEqual( actual );
    	}
    }
