    var pane = zedGraphControl1.GraphPane;
    pane.YAxisList[0].MajorTic.IsOpposite = false;
    pane.YAxisList[0].MinorTic.IsOpposite = false;
    pane.XAxis.MajorTic.IsOpposite = false;
    pane.XAxis.MinorTic.IsOpposite = false;
    pane.AddCurve(null, new[] { 0.1, 0.5, 0.9 }, new[] { 0.8, 0.3, 0.1 }, Color.Blue);
