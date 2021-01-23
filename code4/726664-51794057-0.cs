    var startTS = Convert.ToDateTime("6/17/2018 15:00:00");
    var endTS = Convert.ToDateTime("6/17/2018 18:00:00");
    
    long ticksPerSecond = 10000000;
    long ticksPerMinute = ticksPerSecond * 60;
    long ticksPer45Min = ticksPerMinute * 45;
    long startTSInTicks = startTS.Ticks;
    long endTsInTicks = endTS.Ticks;
    
    for(long i = startTSInTicks; i <= endTsInTicks; i+=ticksPer45Min)
    {
    	new DateTime(i).Dump();
    }
