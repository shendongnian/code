     Public Function hist(ByVal x As Double(), Optional ByVal bins As Integer = 10) As System.Windows.Forms.DataVisualization.Charting.Series
    
            ' HistogramChartHelper is a helper class found in the samples Utilities folder. 
            Dim histogramHelper As New HistogramChartHelper()
    
            ' Specify number of segment intervals
            histogramHelper.SegmentIntervalNumber = bins
    
            ' Create histogram series    
            Dim newSeries As Series = histogramHelper.CreateHistogram(gca(), x, "Histogram")
            gca().ChartAreas(0).AxisX.IsLogarithmic = False
            gca().ChartAreas(0).AxisY.IsLogarithmic = False
            gca().Series.Add(newSeries)
            gcf().DoRefresh()
    
            Return newSeries
        End Function
