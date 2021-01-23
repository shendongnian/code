    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Shapes;
    using System.Windows.Media;
    
    namespace Microsoft.Research.DynamicDataDisplay.PointMarkers
    {
        /// <summary>Adds Rectangle element at every point of graph</summary>
        public class RectangleElementPointMarker : ShapeElementPointMarker
        {
            Polygon Rectangle;
    
            public override UIElement CreateMarker()
            {
                Rectangle = new Polygon();
                Rectangle.Stroke = (Pen != null) ? Pen.Brush : Brushes.White;
                Rectangle.StrokeThickness = (Pen != null) ? Pen.Thickness : 0;
                Rectangle.Fill = Fill;
                Rectangle.HorizontalAlignment = HorizontalAlignment.Center;
                Rectangle.VerticalAlignment = VerticalAlignment.Center;
                Rectangle.Width = Size;
                Rectangle.Height = Size;
    
                Point Point1 = new Point(-Rectangle.Width / 2, -Rectangle.Height / 2);
                Point Point2 = new Point(-Rectangle.Width / 2, Rectangle.Height / 2);
                Point Point3 = new Point(Rectangle.Width / 2, Rectangle.Height / 2);
                Point Point4 = new Point(Rectangle.Width / 2, -Rectangle.Height / 2);
                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                Rectangle.Points = myPointCollection;
    
                if (!String.IsNullOrEmpty(ToolTipText))
                {
                    ToolTip tt = new ToolTip();
                    tt.Content = ToolTipText;
                    Rectangle.ToolTip = tt;
                }
    
                return Rectangle;
            }
    
            public override void SetPosition(UIElement marker, Point screenPoint)
            {
    
                Canvas.SetLeft(marker, screenPoint.X - Size / 2);
                Canvas.SetTop(marker, screenPoint.Y - Size / 2);
            }
        }
    }
