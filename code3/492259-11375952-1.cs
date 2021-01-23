    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;
    namespace WpfApplication9
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Point> _myPointCollection = new ObservableCollection<Point>();
        public ObservableCollection<Point> myPointCollection { get { return _myPointCollection; } }
        public MainWindow()
        {
            myPointCollection.Add(new Point(100, 50));
            myPointCollection.Add(new Point(150, 100));
            myPointCollection.Add(new Point(50, 100));
            InitializeComponent();
            DataContext = this;
        }
        private void ResetPolygon(Point Point1, Point Point2, Point Point3)
        {
            myPointCollection.Clear();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("myPointCollection"));
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
    public class MyPointCollectionConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var regPtsColl = new PointCollection(); //regular points collection.
            var obsPtsColl = (ObservableCollection<Point>)value; //observable which is used to raise INCC event.
            foreach (var point in obsPtsColl)
                regPtsColl.Add(point);
            return regPtsColl;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
        #endregion
    }
    }
