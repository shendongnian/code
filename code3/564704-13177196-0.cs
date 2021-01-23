    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    
    namespace WpfBrownianMotion
    {
        static class MiscUtils
        {
            public static double Clamp(this double n, int low, double high)
            {
                return Math.Min(Math.Max(n, low), high);
            }
        }
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Width = 500;
                Height = 500;
    
                var canvas = new Canvas();
    
                Content = canvas;
    
                var transform = new TranslateTransform(250, 250);
    
                var circle = new Ellipse()
                {
                    Width = 25,
                    Height = 25,
                    Fill = Brushes.PowderBlue,
                    RenderTransform = transform
                };
    
                canvas.Children.Add(circle);
    
                var random = new Random();
    
                var timer = new DispatcherTimer();
    
                timer.Tick += (s, e) =>
                    {
                        transform.X += -1 + random.Next(3);
                        transform.Y += -1 + random.Next(3);
    
                        transform.X = transform.X.Clamp(0, 499);
                        transform.Y = transform.Y.Clamp(0, 499);
                    };
    
                timer.Start();
            }
        }
    }
