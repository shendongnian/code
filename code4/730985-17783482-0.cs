    private void chart1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        // Call Hit Test Method
        HitTestResult result = Chart1.HitTest( e.X, e.Y );    
        if( result.ChartElementType == ChartElementType.DataPoint )
        {  
            Chart1.Series[0].Points[result.PointIndex].Color = Color.Green; 
            // reset the previous point selected here     
        }
    }
