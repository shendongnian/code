      private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
      {
         // Check selected chart element and set tooltip text for it.
         switch (e.HitTestResult.ChartElementType)
         {
            case ChartElementType.DataPoint:
               var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
               e.Text = $"X:\t{dataPoint.XValue}\nY:\t{dataPoint.YValues[0])}";
               break;
         }
      }
