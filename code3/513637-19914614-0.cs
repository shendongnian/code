    var line = new LineObj(Color.Black, xPos, 0, xPos, 1);
    
    line.Location.CoordinateFrame = XScaleYChartFraction; // This do the trick !
    line.IsClippedToChartRect = true;
    
    line.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
    line.Line.Width = 1f;
    myPane.GraphObjList.Add(line);
