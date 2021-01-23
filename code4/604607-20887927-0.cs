    public void Form1()
    {
       //Add a handler for the GetToolTipText event
       chart1.GetToolTipText += new EventHandler<ToolTipEventArgs>(chart1_GetToolTipText);
    }
    private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
    {
       //Check selected chart element is a data point and set tooltip text
       if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
       {   
          //Get selected data point
          DataPoint dataPoint = (DataPoint)e.HitTestResult.Object;
          
          //Is it my datapoint?
          if (dataPoint == myDataPoint)
          {
             //Yes, set text
             e.Text = "My data point value " + dataPoint.XValue.ToString() + dataPoint.YValues[0].ToString();
          }
          else
          {
             //No, void string
             e.Text = "";
          }
       }
    }
