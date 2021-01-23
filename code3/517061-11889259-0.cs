    // The Unix Epoch is 1970-01-01 00:00:00.000
    DateTime   UNIX_EPOCH = new DateTime( 1970 , 1 , 1 ) ;
    
    // The Unix Epoch represented as the number of ticks since the CLR Epoch
    // You can obtain this as UNIX_EPOCH.Ticks
    const long CLR_TICKS_SINCE_UNIX_EPOCH = 621355968000000000 ;
    
    // The number of CLR ticks/second. A CLR tick is 1/10000000 second (100ns).
    // Available as Timespan.TicksPerSecond
    const long CLR_TICKS_PER_SECOND       = 10000000 ;
    
    DateTime dt               = DateTime.Now                           ; // current moment in time
    long     ticks_now        = dt.Ticks                               ; // get its number of ticks
    long     ticks            = ticks_now - CLR_TICKS_SINCE_UNIX_EPOCH ; // compute the current moment in time as the number of ticks since the Unix epoch began.
    long     time_t           = ticks / CLR_TICKS_PER_SECOND           ; // convert that to a time_t, the number of seconds since the Unix Epoch
    DateTime computed         = EPOCH.AddSeconds( time_t )             ;
    // 'computed' is the the current time with 1-second precision.
