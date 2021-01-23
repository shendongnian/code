    public class Thing
	{
		static int Number;
	    static Thing()
	    {
	    	Number = 42; // This will only be called once, no matter how many instances of the class are created
	    }
		// This method is the only means for external code to get a new Thing
	    public static Thing GetNewThing()
	    {
	    	return new Thing();
	    }
	    // This constructor can only be called from within the class.
	    private Thing()
	    {
	    }
	}
     
