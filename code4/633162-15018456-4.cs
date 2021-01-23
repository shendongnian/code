    var fq = 128; // Freq in hz
    var maxDuration = 3600; // max duration in s
    
    var zg1 = new ZedGraphControl();
    zg1.Dock = DockStyle.Fill;
    this.Controls.Add(zg1);
    
    var myPane = zg1.GraphPane;
    myPane.XAxis.Type = AxisType.Date;
    myPane.XAxis.Scale.Format = "yyyy/MM/dd HH:mm:ss.mmm";
    
    var list = new RollingPointPairList(maxDuration * fq);
    
    var ran = new Random();
    var getRandomValue = new Func<double, double, double>((min, max) => ran.NextDouble() * (max - min) + min);
    
    var ts = DateTime.Now;
    
    for (var i = 0; i < list.Capacity; i++)
    {
        list.Add(new XDate(ts), getRandomValue(50d, -50d));
        ts = ts.AddMilliseconds(1000d / fq);
    }
    
    var myCurve = new LineItem("dots", list, Color.Red, SymbolType.None, 1);
    myCurve.Line.IsOptimizedDraw = true;
    myPane.CurveList.Add(myCurve);
    
    zg1.AxisChange();
    zg1.Invalidate();
    
    var z = new Timer();
    z.Interval = 1000;
    z.Tick += (s, ev) =>
        {
            var points = myCurve.Points as RollingPointPairList;
            for (var i = 0; i < fq; i++)
            {
                points.Add(new XDate(ts), getRandomValue(50d, -50d));
                ts = ts.AddMilliseconds(1000d / fq);
            }
    
            zg1.Invalidate();
        };
    
    z.Start();
