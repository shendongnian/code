    using System;
    using System.Windows;
    using System.Windows.Media;
    namespace WpfApplication9
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PointCollection myPointCollection { get; set; }
        public MainWindow()
        {
            myPointCollection = new PointCollection
            {
                new Point(100, 50),
                new Point(150, 100),
                new Point(50, 100)
            };
            InitializeComponent();
            DataContext = this;
        }
        private void ResetPolygon(Point Point1, Point Point2, Point Point3)
        {
            myPointCollection[0] = Point1;
            myPointCollection[1] = Point2;
            myPointCollection[2] = Point3;
            DataContext = null;
            DataContext = this;
        }
        private void Window_LocationChanged(object sender, EventArgs e)
        {
            if (this.IsLoaded)
            {
                Random rnd = new Random();
                Point Point1 = new Point(rnd.Next(50, 200), rnd.Next(50, 200));
                Point Point2 = new Point(rnd.Next(50, 200), rnd.Next(50, 200));
                Point Point3 = new Point(rnd.Next(50, 200), rnd.Next(50, 200));
                ResetPolygon(Point1, Point2, Point3);
            }
        }
    }
    }
