    Series series = chart.SeriesCollection.AddSeries();
    series.Add(new double[] { 3, 10, 10, 150, 7, 192, 6 });
    var elements = series.Elements.Cast<MigraDoc.DocumentObjectModel.Shapes.Charts.Point>().ToArray();
    elements[0].FillFormat.Color = Colors.Chartreuse;
    elements[3].FillFormat.Color = Colors.DeepSkyBlue;
