        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.Position = trackBar2.Value;
            chart1.ChartAreas[1].AxisX.ScaleView.Position = trackBar2.Value;
            (etc for however many chart areas you have)
        }
