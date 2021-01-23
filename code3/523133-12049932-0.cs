	public static void Main ( string[] Args )
	{
		PipeClient obj = new PipeClient ();
		obj.client (); // <-- This has an endless loop and won't return
		// So the following lines  will never be executed!
		Thread startserver = new Thread ( new ThreadStart ( obj.server ) ); 
		startserver.Start ();
	}
