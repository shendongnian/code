    #if INCLUDE_FOR_TEST_ONLY
    public static class BarsForTestOnly
    {
    	public static Bar Create( string id )
    	{
    		return new Bar( id );
    	}
    }
    #endif
