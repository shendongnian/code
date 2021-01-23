    StripLine stripLine = new StripLine();    
    stripLine.Interval = 0;       // Set Strip lines interval to 0 for non periodic stuff
    stripLine.StripWidth = 10;    // the width of the highlighted area
    stripline.IntervalOffset = 2; // the starting X coord of the highlighted area
    // pick you color etc ... before adding the stripline to the axis
    chart.ChartAreas["Default"].AxisX.StripLines.Add( stripLine );
