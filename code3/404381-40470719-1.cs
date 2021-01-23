    TraceLevel(Level.All); //-2147483648
    
    TraceLevel(Level.Verbose);   //  10 000
    TraceLevel(Level.Finest);    //  10 000
        
    TraceLevel(Level.Trace);     //  20 000
    TraceLevel(Level.Finer);     //  20 000
        
    TraceLevel(Level.Debug);     //  30 000
    TraceLevel(Level.Fine);      //  30 000
        
    TraceLevel(Level.Info);      //  40 000
    TraceLevel(Level.Notice);    //  50 000
        
    TraceLevel(Level.Warn);      //  60 000
    TraceLevel(Level.Error);     //  70 000
    TraceLevel(Level.Severe);    //  80 000
    TraceLevel(Level.Critical);  //  90 000
    TraceLevel(Level.Alert);     // 100 000
    TraceLevel(Level.Fatal);     // 110 000
    TraceLevel(Level.Emergency); // 120 000
        
    TraceLevel(Level.Off); //2147483647
    private static void TraceLevel(log4net.Core.Level level)
    {
       Debug.WriteLine("{0} = {1}", level, level.Value);
    }
