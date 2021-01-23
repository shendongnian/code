        Dim Xmin As Double = aChart.ChartAreas(0).AxisX.ScaleView.ViewMinimum
        Dim Xmax As Double = aChart.ChartAreas(0).AxisX.ScaleView.ViewMaximum
        Dim Ymin As Double = aChart.ChartAreas(0).AxisY.ScaleView.ViewMinimum
        Dim Ymax As Double = aChart.ChartAreas(0).AxisY.ScaleView.ViewMaximum
        Dim VisibleDataPoints As New Series
        For Each pt As System.Windows.Forms.DataVisualization.Charting.DataPoint In aChart.Series(0).Points
            If pt.XValue >= Xmin And pt.XValue <= Xmax Then
                If pt.YValues(0) >= Ymin And pt.YValues(0) <= Ymax Then
                    VisibleDataPoints.Points.Add(pt)
                End If
            End If
        Next
        VisibleDataPoints.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        VisibleDataPoints.Color = Color.Red
        aChart.Series.Add(VisibleDataPoints)
