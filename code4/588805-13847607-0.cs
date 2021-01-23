    private void chData_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    chData.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    chData.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }
                if (e.Delta > 0)
                {
                    double xMin = chData.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = chData.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = chData.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = chData.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
                    double posXStart = chData.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    double posXFinish = chData.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    double posYStart = chData.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    double posYFinish = chData.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;
                    chData.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                    chData.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }            
        }
