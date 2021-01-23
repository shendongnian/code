    StripLine stripLine = new StripLine();
    // highlight a strip of 8 hours in the X axis
    stripLine.StripWidth = 8;
    stripLine.StripWidthType = DateTimeIntervalType.Hours;
    stripLine.BackColor = System.Drawing.Color.PapayaWhip;
    stripLine.BorderColor = System.Drawing.Color.LightSeaGreen;
    stripLine.BorderWidth = 2;
    // start the highlighting 7 hours in (from 07:00 to 15:00)
    stripLine.IntervalOffset = 7;
    stripLine.IntervalOffsetType = DateTimeIntervalType.Hours;
    // repeat this strip every 1 day
    stripLine.Interval = 1;
    stripLine.IntervalType = DateTimeIntervalType.Days;
    this.TopOfBookChart.ChartAreas[0].AxisX.StripLines.Add(stripLine);
