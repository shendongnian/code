        this.chart1.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.Chart1_GetToolTipText);
    ...
    // [2] in x.cs file.
    private void Chart1_GetToolTipText(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
    {
     
       // Check selevted chart element and set tooltip text
       if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
       {
          int i = e.HitTestResult.PointIndex;
          DataPoint dp = e.HitTestResult.Series.Points[i];
          e.Text = string.Format("{0:F1}, {1:F1}", dp.XValue, dp.YValues[0] );
       }
    }
