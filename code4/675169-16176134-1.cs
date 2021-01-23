    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace TestWPF
    {
        public partial class CircleTest : UserControl, INotifyPropertyChanged
        {
            public CircleTest()
            {
                InitializeComponent();
    
                this.SizeChanged += CircleTest_SizeChanged;
            }
    
            void CircleTest_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
            {
                double radius;
                if (ActualHeight < ActualWidth)
                {
                    Width = ActualHeight;
                    _center = new Point(Width / 2, ActualHeight / 2);
                    radius = ActualHeight / 2;
                }
                else
                {
                    Height = ActualWidth;
                    _center = new Point(ActualWidth / 2, Height / 2);
                    radius = ActualWidth / 2;
                }
    
                _endPoint = new Point(Center.X, Center.Y - radius);
    
                NotifyOfPropertyChange("Center");
                NotifyOfPropertyChange("EndPoint");
            }
    
            public double Angle
            {
                get { return (double)GetValue(AngleProperty); }
                set { SetValue(AngleProperty, value); }
            }
            public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(CircleTest), new PropertyMetadata(45.0));
    
            private Point _center;
            public Point Center
            {
                get { return _center; }
            }
    
            private Point _endPoint;
            public Point EndPoint
            {
                get { return _endPoint; }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyOfPropertyChange(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
