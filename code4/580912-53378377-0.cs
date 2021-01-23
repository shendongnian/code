    using System;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    namespace ExampleApp
    {
        public partial class Form1 : Form
        {
            private int FZoomLevel = 0;
            public Form1()
            {
                InitializeComponent();
                chart1.MouseWheel += Chart1_MouseWheel;
            }
            private void Chart1_MouseEnter(object sender, EventArgs e)
            {
                if (!chart1.Focused)
                    chart1.Focus();
            }
            private void Chart1_MouseLeave(object sender, EventArgs e)
            {
                if (chart1.Focused)
                    chart1.Parent.Focus();
            }
            private void Chart1_MouseWheel(object sender, MouseEventArgs e)
            {
                try {
                    Axis xAxis = chart1.ChartAreas[0].AxisX;
                    double xMin = xAxis.ScaleView.ViewMinimum;
                    double xMax = xAxis.ScaleView.ViewMaximum;
                    double xPixelPos = xAxis.PixelPositionToValue(e.Location.X);
                    if (e.Delta < 0 && FZoomLevel > 0) {
                        // Scrolled down, meaning zoom out
                        if (--FZoomLevel <= 0) {
                            FZoomLevel = 0;
                            xAxis.ScaleView.ZoomReset();
                        } else {
                            double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) * CZoomScale, 0);
                            double xEndPos = Math.Min(xStartPos + (xMax - xMin) * CZoomScale, xAxis.Maximum);
                            xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                        }
                    } else if (e.Delta > 0) {
                        // Scrolled up, meaning zoom in
                        double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) / CZoomScale, 0);
                        double xEndPos = Math.Min(xStartPos + (xMax - xMin) / CZoomScale, xAxis.Maximum);
                        xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                        FZoomLevel++;
                    }
                } catch { }
            }
        }
    }
