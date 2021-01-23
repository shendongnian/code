    Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                .SetTitle(new Title { Text = "Stacked column chart" })
                .SetXAxis(new XAxis { Categories = new[] { "Championships 1", "Championships 2", "Championships 3", "Championships 4" } })
                .SetPlotOptions(new PlotOptions { Column = new PlotOptionsColumn { Stacking = Stackings.Normal } })
                .SetSeries(new[]
                           {
                               new Series { Name = "Audio", Data = new Data(new object[] { 17, 2, 10, 10 }) },
                               new Series { Name = "Video", Data = new Data(new object[] { 15, 5, 3, 3 }) },
                               new Series { Name = "Peripheral", Data = new Data(new object[] { 6, 16, 16, 16 }) }
                           });
