    ZedGraphControl zg1 = new ZedGraphControl();
    zg1.Dock = DockStyle.Fill;
    zg1.GraphPane = new GraphPane();
            
    BarItem myBar = new BarItem("Bar1");
    myBar.AddPoint(1, 10);
    myBar.AddPoint(2, 20);
    myBar.Bar.Fill = new Fill(Color.AliceBlue, Color.White, Color.AliceBlue);
    zg1.GraphPane.CurveList.Add(myBar);
            
            
    zg1.AxisChange();
    zg1.Invalidate();
    zg1.Show();
    this.Controls.Add(zg1);
