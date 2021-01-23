    LineObj line = new LineObj(Color.Red, 
                       myPane.XAxis.Scale.Min, 100, myPane.XAxis.Scale.Max, 100);
    line.Location.CoordinateFrame = CoordType.AxisXYScale;   
    line.Location.AlignH = AlignH.Left;
    line.Location.AlignV = AlignV.Top;   
    line.ZOrder = ZOrder.E_BehindAxis;
    myPane.GraphObjList.Add(line);
