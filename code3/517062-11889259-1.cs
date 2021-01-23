    // The Unix epoch is 1970-01-01 00:00:00.000
    DateTime   UNIX_EPOCH = new DateTime( 1970 , 1 , 1 ) ;
    
    // The Unix epoch represented in CLR ticks.
    // This is also available as UNIX_EPOCH.Ticks
    const long UNIX_EPOCH_IN_CLR_TICKS = 621355968000000000 ;
    
    // A CLR tick is 1/10000000 second (100ns).
    // Available as Timespan.TicksPerSecond
    const long CLR_TICKS_PER_SECOND = 10000000 ;
    
    DateTime now       = DateTime.Now                        ; // current moment in time
    long     ticks_now = now.Ticks                           ; // get its number of tics
    long     ticks     = ticks_now - UNIX_EPOCH_IN_CLR_TICKS ; // compute the current moment in time as the number of ticks since the Unix epoch began.
    long     time_t    = ticks / CLR_TICKS_PER_SECOND        ; // convert that to a time_t, the number of seconds since the Unix Epoch
    DateTime computed  = EPOCH.AddSeconds( time_t )          ; // and convert back to a date time value
    
    // 'computed' is the the current time with 1-second precision.
