     Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Chart1.Series(0).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series(0).Points.AddXY(0, 10)
            Chart1.Series(0).Points.AddXY(1440, 100)
            Chart1.Series(0).Points.AddXY(600, 80)
    
            Chart2.Series(0).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            Chart2.Series(0).Points.AddXY(0, 10)
            Chart2.Series(0).Points.AddXY(1440, 100)
            Chart2.Series(0).Points.AddXY(600, 80)
    
            Chart1.DataManipulator.Sort(System.Windows.Forms.DataVisualization.Charting.PointSortOrder.Descending, Chart1.Series(0))
    
        End Sub
