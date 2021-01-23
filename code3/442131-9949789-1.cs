    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Threading;
    
    namespace WpfApplication1
    {
        public partial class Spirograph : UserControl
        {
            private DispatcherTimer _timer;
            private int _pointIndex = 0;
            private List<Point> _points;
            private bool _loaded = false;
            
            public Spirograph()
            {
                _points = new List<Point>();
                CalculatePoints();
    
                InitializeComponent();
    
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromMilliseconds(Delay);
                _timer.Tick += TimerTick;
    
                this.Loaded += SpirographLoaded;
                this.SizeChanged += SpirographSizeChanged;
            }
    
            void SpirographSizeChanged(object sender, SizeChangedEventArgs e)
            {
                bool running = Running;
                Reset();
                StartPoint = new Point((this.ActualWidth / 2) - Radius, (this.ActualHeight / 2) - Radius);
    
                if (running)
                    Start();
            }
    
            void SpirographLoaded(object sender, RoutedEventArgs e)
            {
                _loaded = true;
                if (AutoStart)
                    Start();
            }
    
            void TimerTick(object sender, EventArgs e)
            {
                if (_pointIndex >= PointCount)
                    Stop();
                else
                    _figure.Segments.Add(new LineSegment(_points[_pointIndex], true));
                
                _pointIndex++;
            }
    
            public bool Running { get; protected set; }
    
    
            public bool AutoStart
            {
                get { return (bool)GetValue(AutoStartProperty); }
                set { SetValue(AutoStartProperty, value); }
            }
            public static readonly DependencyProperty AutoStartProperty = DependencyProperty.Register("AutoStart", typeof(bool), typeof(Spirograph), new UIPropertyMetadata(true));
    
            public int PointCount
            {
                get { return (int)GetValue(PointCountProperty); }
                set { SetValue(PointCountProperty, value); }
            }
            public static readonly DependencyProperty PointCountProperty = DependencyProperty.Register("PointCount", typeof(int), typeof(Spirograph), new UIPropertyMetadata(100, new PropertyChangedCallback(PointCountPropertyChanged)));
    
            private static void PointCountPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                Spirograph spirograph = sender as Spirograph;
                if (spirograph != null)
                    spirograph.PointCountPropertyChanged(e);
            }
            private void PointCountPropertyChanged(DependencyPropertyChangedEventArgs e)
            {
                bool running = Running;
                Reset();
                CalculatePoints();
                if (running)
                    Start();
            }
           
            #region Delay
    
            public int Delay
            {
                get { return (int)GetValue(DelayProperty); }
                set { SetValue(DelayProperty, value); }
            }
            public static readonly DependencyProperty DelayProperty = DependencyProperty.Register("Delay", typeof(int), typeof(Spirograph), new UIPropertyMetadata(30, new PropertyChangedCallback(DelayPropertyChanged)));
    
            private static void DelayPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                Spirograph spirograph = sender as Spirograph;
                if (spirograph != null)
                    spirograph.DelayPropertyChanged(e);
            }
            private void DelayPropertyChanged(DependencyPropertyChangedEventArgs e)
            {
                bool running = Running;
                Stop();
                _timer.Interval = TimeSpan.FromMilliseconds((int)e.NewValue);
    
                if (running)
                    Start();
            }
    
            #endregion
    
            public double Radius
            {
                get { return (double)GetValue(RadiusProperty); }
                set { SetValue(RadiusProperty, value); }
            }
            public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(Spirograph), new UIPropertyMetadata(10.0));
    
    
            public Point StartPoint
            {
                get { return (Point)GetValue(StartPointProperty); }
                set { SetValue(StartPointProperty, value); }
            }
            public static readonly DependencyProperty StartPointProperty = DependencyProperty.Register("StartPoint", typeof(Point), typeof(Spirograph), new UIPropertyMetadata(new Point(0, 0), new PropertyChangedCallback(StartPointPropertyChanged)));
    
            private static void StartPointPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                Spirograph spirograph = sender as Spirograph;
                if (spirograph != null)
                    spirograph.StartPointPropertyChanged(e);
            }
            private void StartPointPropertyChanged(DependencyPropertyChangedEventArgs e)
            {
                bool running = Running;
                Stop();
                StartPoint = (Point)e.NewValue;
                CalculatePoints();
                if (running)
                    Start();
            }
    
            public Brush Stroke
            {
                get { return (Brush)GetValue(StrokeProperty); }
                set { SetValue(StrokeProperty, value); }
            }
            public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register("Stroke", typeof(Brush), typeof(Spirograph), new UIPropertyMetadata(new SolidColorBrush(Colors.Blue)));
    
            public Thickness StrokeThickness
            {
                get { return (Thickness)GetValue(StrokeThicknessProperty); }
                set { SetValue(StrokeThicknessProperty, value); }
            }
            public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(Thickness), typeof(Spirograph), new UIPropertyMetadata(new Thickness(1)));
    
       
            public void Start()
            {
                if (!_loaded)
                    AutoStart = true;
                else
                {
                    Running = true;
                    _timer.Start();
                }
            }
    
            public void Stop()
            {
                Running = false;
                _timer.Stop();
            }
    
            public void Reset()
            {
                Stop();
                _figure.Segments.Clear();
                _pointIndex = 0;
            }
          
            private void CalculatePoints()
            {
                _points.Clear();
                Point lastPoint = StartPoint;
                double a = 0.0;
    
                double rr = 0.5 * Radius;
      
    
                for (int i = 0; i <= PointCount; i++)
                {
                    Point pt = new Point();
                    pt.X = lastPoint.X + Radius * Math.Cos(a);
                    pt.Y = lastPoint.Y + Radius * Math.Sin(a);
                    _points.Add(pt);
                    double aa = -0.8 * a;
                    Point pnt = new Point();
                    pnt.X = pt.X + rr * Math.Cos(aa);
                    pnt.Y = pt.Y + rr * Math.Sin(aa);
                    a += 0.5;
                    _points.Add(pnt);
                    lastPoint = pnt;
                }
            }
        }
    }
