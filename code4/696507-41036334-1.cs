    using Microsoft.Research.DynamicDataDisplay.Charts;
    ...
    ChartPlotter PlotterOne = new ChartPlotter();
    // Add a Graph to One:
    GridOne.Children.Add(PlotterOne);
    LineGraph line = new LineGraph();
    line.ProvideVisiblePoints = true;
    line.Stroke = Brushes.Blue;
    line.StrokeThickness = 1;
    line.DataSource = GetDayDataSource();
    Legend.SetDescription(line, "Today's Activity");
    PlotterOne.Children.Add(line);
