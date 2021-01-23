    private void myChart_GetToolTipText(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
    {
        switch(e.HitTestResult.ChartElementType)
        {  
            case ChartElementType.DataPoint:
                e.Text = myChart.Series[0].Points[e.HitTestResult.PointIndex]).ToString()
                         + /* something for which no keyword exists */;
                break;
            case ChartElementType.Axis:
                // add logic here
            case ....
            .
            .    
            default:
                // do nothing       
        }
   
