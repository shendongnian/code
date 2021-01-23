    class MyTraceSource
    {
      private TraceSource ts;
      public MyTraceSource(string name)
      {
        ResolveTraceSource(name);
      }
      private void ResolveTraceSource(string name)
      {
        //Check for a configured TraceSource from most qualified name (as input) to least qualified ("").
        //Assume name like this:  Namespace1:Namespace2:Class
        //Try to resolve:
        // TraceSource("Namespace1.Namespace2.Class");
        // TraceSource("Namespace1.Namespace2");
        // TraceSource("Namespace1");
        //If you still haven't found one, try to resolve
        // TraceSource("*");
      }
      //Implement either TraceSource API, or whatever API you prefer for logging.
    }
