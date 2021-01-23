    chart1.ChartAreas[0].Axes[0].Title = "N";
    chart1.ChartAreas[0].Axes[1].Title = "FIB(N)";
    chart1.Series[0].ChartType = SeriesChartType.Line;
    chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
    chart1.Series[0].LegendText = "Fibonacci numbers";
    Tuple<int,int> t = Tuple.Create(0,1);
    
    for(int i = 1; i <= 30; i++){
      chart1.Series[0].Points.Add(newDataPoint(i, t.Item1));
      t = Tuple.Create(t.Item2, t.Item1 + t.Item2);
    }
