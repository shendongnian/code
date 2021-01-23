    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    namespace BackgroundThreadUpdate
    {
        public partial class MainWindow : Window
        {
            private MySource _src;
            public MainWindow()
            {
                InitializeComponent();
                _src = new MySource();
                DataContext = _src;
            }
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                Task.Run(() =>
                {
                    for (int i = 0; i < 100; ++i)
                    {
                        Thread.Sleep(100);
                        _src.CompassLogLoadPercent = i;
                    }
                });
            }
        }
        public class MySource : INotifyPropertyChanged
        {
            private double _compassLogLoadPercent;
            public double CompassLogLoadPercent
            {
                get
                {
                    return _compassLogLoadPercent;
                }
                set
                {
                    if (_compassLogLoadPercent != value)
                    {
                        _compassLogLoadPercent = value;
                        OnPropertyChanged("CompassLogLoadPercent");
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
