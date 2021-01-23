     // Create an empty chart.
     ChartControl pieChart = new ChartControl();
     // Create a pie series.
     Series series1 = new Series("A Pie Series", ViewType.Pie);
     // Populate the series with points.
     series1.Points.Add(new SeriesPoint("No Results found", 100));
     // Add the series to the chart.
     pieChart.Series.Add(series1);
