        protected void myZg_Resize(object sender, EventArgs e)
        {
            GraphPane pane = myZg.GraphPane;
            myZg.AxisChange();
            bool IsXMin = ( pane.Rect.Width < pane.Rect.Height ) ? true : false;
            if (IsXMin)
            {   
                // Scale based on X (width)
                pane.XAxis.Scale.Max = (radius + 20); pane.XAxis.Scale.Min = -(radius + 20);
                double xPixPerUnit = (double)pane.Chart.Rect.Width / (pane.XAxis.Scale.Max - pane.XAxis.Scale.Min);
                pane.YAxis.Scale.Max = (double)pane.Chart.Rect.Height / xPixPerUnit / 2.0;
                pane.YAxis.Scale.Min = -pane.YAxis.Scale.Max;
                myZg.AxisChange();
            }
            else
            {
                // Scale based on Y (height)
                pane.YAxis.Scale.Max = (radius + 20); pane.YAxis.Scale.Min = -(radius + 20);
                double yPixPerUnit = (double)pane.Chart.Rect.Height / (pane.YAxis.Scale.Max - pane.YAxis.Scale.Min);
                pane.XAxis.Scale.Max = (double)pane.Chart.Rect.Width / yPixPerUnit / 2.0;
                pane.XAxis.Scale.Min = -pane.XAxis.Scale.Max;
                myZg.AxisChange();
            }
        }
