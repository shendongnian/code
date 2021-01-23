    string[] books= source.Select(a => a.bookName).ToArray();
    object[] visits = source.Select(a => (object)a.Visits).ToArray();
    DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
                     .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar,
                                            Width = 900 
                      }).SetPlotOptions(new PlotOptions {
                           Bar = new PlotOptionsBar {
                                         ColorByPoint = true,
                                         DataLabels = new PlotOptionsBarDataLabels {
                                                              Enabled = true }
                                         }
                     }).SetXAxis(new XAxis { Categories = books,
                     }).SetSeries(new Series
	                         {
	                             Data = new Data(visits),
	                             Name = "User Book Visits"
	                         });
    lb_chart.Text = chart.ToHtmlString();
