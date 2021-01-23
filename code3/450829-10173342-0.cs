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
            
    PointPairList list = new PointPairList();
    for (int i = 0; i < 36; i++)
    {
        double x = i * 5.0;
        double y = new XDate(DateTime.Now.AddSeconds(i));
        list.Add(x, y);
                
        listBox1.Items.Add("x = " + x + " y = " + y);
     }
     LineItem myCurve = myPane.AddCurve("Alpha",
                                        list,
                                        Color.Red,
                                        SymbolType.None);
            
     myCurve.Symbol.Fill = new Fill(Color.White);
     myCurve.IsX2Axis = true;
     myCurve.IsY2Axis = true;
     myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
     zg1.IsShowPointValues = true;
            
     zg1.AxisChange();
     zg1.Invalidate();
