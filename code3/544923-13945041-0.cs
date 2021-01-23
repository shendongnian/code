    static void Main( string[ ] args ){
      Trace.Listeners.Clear();
      Trace.Listeners.Add( new ConsoleTraceListener( ) );
      Trace.TraceInformation( "Hello world" );
      Trace.Fail("A failure");
    }
	
