      // column - Clicks
                                var chartType3 = chart.PlotArea.ChartTypes.Add(eChartType.ColumnClustered);
                                var series2 = chartType3.Series.Add("=" + countryName + "!$C$29:$C$" + chartrange, "=" + countryName + "!$A$29:$A$" + chartrange);
                                series2.Header = "Clicks To Dealer";
                                chartType3.UseSecondaryAxis = true;
