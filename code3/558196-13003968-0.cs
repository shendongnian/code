    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    
    namespace Stock
    {
        /// <summary>
        /// Interaction logic for ListBox.xaml
        /// </summary>
        public partial class Chart : Window
        {
            private Point _capturePoint;
            private double _captureLeft;
            private double _captureTop;
    
            public Chart()
            {
                InitializeComponent();
    
            }
    
            protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
            {
                base.OnMouseLeftButtonDown(e);
    
                _capturePoint = e.GetPosition(chart);
                _captureLeft = Canvas.GetLeft(chart);
                _captureTop = Canvas.GetTop(chart);
    
                if (_capturePoint.X > 0 && _capturePoint.X < chart.RenderSize.Width &&
                    _capturePoint.Y > 0 && _capturePoint.Y < chart.RenderSize.Height) 
                {
                    CaptureMouse();
                }
                
            }
    
            protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
            {
                base.OnMouseLeftButtonUp(e);
                ReleaseMouseCapture();
            }
    
            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
    
                if (Mouse.Captured == this)
                {
                    var currentPoint = e.GetPosition(chart);
                    var diff = Point.Subtract(currentPoint, _capturePoint);
    
                    Canvas.SetTop(chart, _captureTop + diff.Y);
                    Canvas.SetLeft(chart, _captureLeft + diff.X);
                }
            }
        }
    }
