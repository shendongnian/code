    Steema.TeeChart.Styles.Candle candleSeries1;
    Random r;
    double tmpOpen;
    double tmpClose;
    int count;
    DateTime dt;
    TimeSpan ts;
    private void InitializeChart()
    {
        tChart1.Aspect.View3D=false;
        tChart1.AutoRepaint = false;
         r = new Random();
        candleSeries1.Clear();
        candleSeries1.XValues.DateTime = true;
        candleSeries1.GetHorizAxis.Labels.Angle = 90;
        count = 0;
        dt = DateTime.Today;
        ts = TimeSpan.FromDays(1);
        candleSeries1.Pen.Visible = false;
        for (int t=0;t<30000;t++)
        {
            tmpOpen = r.Next(100);
            tmpClose = tmpOpen - r.Next(100);
                ++count;
                candleSeries1.Add(dt,tmpOpen,tmpOpen + r.Next(50),
                    tmpClose -r.Next(50),tmpClose);
            dt += ts;
        }
        tChart1.AutoRepaint = true;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        tmpOpen = r.Next(100);
        tmpClose = tmpOpen - r.Next(100);
        candleSeries1[candleSeries1.LastVisibleIndex].Close = tmpOpen;
   
    }
