    ChartArea chartarea = new ChartArea();
    Series Memory = new Series();
    RepeatsMemoryPlot.Series.Add(Memory);
    //Add points to series Memory
    Memory.Points.AddXY(a, b);
    Series Time = new Series();
    RepeatsMemoryPlot.Series.Add(Time);
    Time.ChartArea = Memory.ChartArea;
    Time.YAxisType = AxisType.Secondary;
    //Add Points to time series
    Time.Points.AddXY(a, b);
