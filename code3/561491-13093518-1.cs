    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace CanvasScale
    {
        public static class CanvasUtils
        {
            public static Canvas SetCoordinateSystem(this Canvas canvas, Double xMin, Double xMax, Double yMin, Double yMax)
            {
                var width = xMax - xMin;
                var height = yMax - yMin;
    
                var translateX = width / 2.0;
                var translateY = height / 2.0;
    
                var group = new TransformGroup();
    
                group.Children.Add(new TranslateTransform(translateX, -translateY));
                group.Children.Add(new ScaleTransform(canvas.ActualWidth / width, canvas.ActualHeight / -height));
    
                canvas.RenderTransform = group;
    
                return canvas;
            }
        }
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var canvas = new Canvas();
    
                Content = canvas;
    
                SizeChanged += (s, e) => canvas.SetCoordinateSystem(-10, 10, -10, 10);                
    
                canvas.Children.Add(new Line() { X1 = -10, Y1 = 0, X2 = 10, Y2 = 0, Stroke = Brushes.Black, StrokeThickness = 0.2 });
                canvas.Children.Add(new Line() { X1 = 0, Y1 = -10, X2 = 0, Y2 = 10, Stroke = Brushes.Black, StrokeThickness = 0.2 });
    
                var polyline = new Polyline()
                {
                    Stroke = Brushes.BurlyWood,
                    StrokeThickness = 0.1,
                    Points = new PointCollection()
                };
    
                for (var x = -10.0; x <= 10.0; x += 0.1)
                    polyline.Points.Add(new Point(x, Math.Sin(x)));
    
                canvas.Children.Add(polyline);
            }
        }
    }
