    namespace DrawingExtensions
    {
        using System.Windows.Forms.DataVisualization.Charting;
        using System.Drawing;
        
        public static class Forms
        {
            public PointF ToPointF(this DataPoint source)
            {
                return new PointF(
                    Convert.ToSingle(source.XValue),
                    Convert.ToSingle(source.YValue));
            }
            public Point ToPoint(this DataPoint source)
            {
                return new Point(
                    Convert.ToInt32(source.XValue),
                    Convert.ToInt32(source.YValue));
            }
        }
    }
