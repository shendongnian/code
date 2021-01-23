    static void Main( string[ ] args ){
      Trace.Listeners.OfType<DefaultTraceListener>().First().AssertUiEnabled = false;
      Trace.TraceInformation( "Hello world" );
      Trace.Fail("A failure");
    }
	
