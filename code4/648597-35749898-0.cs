    private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
    {
        foreach (var charArea in chart1.ChartAreas)
        {
            if (charArea != e.ChartArea)
            {
                double x_position = e.ChartArea.AxisX.ScaleView.Position;
                double x_size = e.ChartArea.AxisX.ScaleView.Size;
                charArea.AxisX.ScaleView.Zoom(x_position, x_position + x_size);    
            }        		 
        }            
    }
