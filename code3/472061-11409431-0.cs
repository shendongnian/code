    chart1.AxisScrollBarClicked += new ScrollBarEventHandler(this.chart1_AxisScrollBarClicked);
    ...
    private void chart1_AxisScrollBarClicked(object sender, ScrollBarEventArgs e)
    {
      // Handle zoom reset button
      if(e.ButtonType == ScrollBarButtonType.ZoomReset)        
      {
        e.IsHandled = true;
        double x_view_start, x_view_end, y_view_start, y_view_end;
        // calculate the zooming params here according to desired behaviour
                
        e.ChartArea.AxisX.ScaleView.Zoom(x_view_start, x_view_end);
        e.ChartArea.AxisY.ScaleView.Zoom(y_view_start, y_view_end);
      }
    }
