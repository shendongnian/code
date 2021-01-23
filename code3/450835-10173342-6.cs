    GraphPane myPane = zg1.GraphPane;            
    myPane.XAxis.IsVisible = false;
    myPane.X2Axis.IsVisible = true;
    myPane.X2Axis.MajorGrid.IsVisible = true;
    myPane.X2Axis.Scale.Min = 0;
    myPane.X2Axis.Scale.Max = 600;
    myPane.YAxis.IsVisible = false;
    myPane.Y2Axis.IsVisible = true;
    myPane.Y2Axis.Scale.MajorUnit = DateUnit.Minute;
    myPane.Y2Axis.Scale.MinorUnit = DateUnit.Second;
    myPane.Y2Axis.Scale.Format = "HH:mm:ss";
    myPane.Y2Axis.Type = AxisType.DateAsOrdinal;
    // As we get more data we want to add it on to the end of the curve
    // and we also want to get the scale so that we can shift it along
    double? oringinalLastDate;
    XDate firstDate;
    LineItem myCurve;
    if(myPane.CurveList.Count == 0)
    {
        myCurve = myPane.AddCurve("Alpha",
                                  new PointPairList(),
                                  Color.Red,
                                  SymbolType.None);
        firstDate = new XDate(DateTime.Now);
        oringinalLastDate = null;
    }
    else
    {
        myCurve = (LineItem)myPane.CurveList[0];
        firstDate = myCurve.Points[myCurve.Points.Count - 1].Y;
        oringinalLastDate = myPane.Y2Axis.Scale.Max;
    }            
    for (int i = 0; i < 36; i++)
    {
        double x = i * 5.0;
        firstDate.AddSeconds(i);
        myCurve.AddPoint(x, firstDate);
        listBox1.Items.Add("x = " + x + " y = " + firstDate);
    }
    
    myCurve.Symbol.Fill = new Fill(Color.White);
    myCurve.IsX2Axis = true;
    myCurve.IsY2Axis = true;
    
    myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
    zg1.IsShowPointValues = true;
    // Now make the minimum of the scale, the maximum that it was so
    // the graph shifts
    if (oringinalLastDate.HasValue)
        myPane.Y2Axis.Scale.Min = oringinalLastDate.Value;
    zg1.AxisChange();            
    zg1.Invalidate();
