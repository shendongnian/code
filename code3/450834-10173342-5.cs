    private int pointCount;
    private double? scaleMin = null;
    private static readonly Random rnd = new Random();
    private void button1_Click(object sender, EventArgs e)
    {
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
        LineItem myCurve = myPane.AddCurve("Alpha",
                                      new PointPairList(),
                                      Color.Red,
                                      SymbolType.None);
        myCurve.Symbol.Fill = new Fill(Color.White);
        myCurve.IsX2Axis = true;
        myCurve.IsY2Axis = true;
        myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
        zg1.IsShowPointValues = true;
        pointCount = 0;
        new System.Threading.Timer(
            ShowData,
            null,
            100,
            1000);
    }
    private void ShowData(object Object)
    {
        pointCount++;
        int x = rnd.Next(500, 600);
        var y = new XDate(DateTime.Now);
        GraphPane myPane = zg1.GraphPane;
        if (scaleMin == null) scaleMin = myPane.Y2Axis.Scale.Max;
        LineItem myCurve = (LineItem)myPane.CurveList[0];            
        myCurve.AddPoint(x, y);
        // After 3 points are added move the scale along
        if (pointCount > 3)
        {
            myPane.Y2Axis.Scale.Min = scaleMin.Value;
            scaleMin = myPane.Y2Axis.Scale.Max;
        }
        zg1.AxisChange();
        zg1.Invalidate();
    }
