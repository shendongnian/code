    var averages = new
    {
        Plus100 = dtPointCollFb.Average(item => item.PLUS100),
        Plus50 = dtPointCollFb.Average(item => item.PLUS50),
        Plus10 = dtPointCollFb.Average(item => item.PLUS10),
        Plus5 = dtPointCollFb.Average(item => item.PLUS5),
        Plus1 = dtPointCollFb.Average(item => item.PLUS1),
        NULLA = dtPointCollFb.Average(item => item.NULLA)
    };
