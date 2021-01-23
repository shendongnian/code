    Series seriesA = chart.SeriesCollection.AddSeries();
    seriesA.Add(new double[] { 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
    seriesA.FillFormat.Color = Colors.AliceBlue;
    Series seriesB = chart.SeriesCollection.AddSeries();
    seriesB.Add(new double[] { 0, 20, 0, 0, 0, 0, 0, 0, 0, 0 });
    seriesB.FillFormat.Color = Colors.DarkGray;
    Series seriesC = chart.SeriesCollection.AddSeries();
    seriesC.Add(new double[] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0 });
    seriesC.FillFormat.Color = Colors.Red;
